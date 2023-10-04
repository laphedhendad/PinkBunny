using UnityEditor;
using UnityEngine;

namespace Laphed.AnimationCurveInspectorExtension
{
    [CustomPropertyDrawer(typeof(AnimationCurveExtension))]
    public class AnimationCurvePropertyDrawer: PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            
            SerializedProperty curveProperty = property.FindPropertyRelative("curve");
            SerializedProperty pointsProperty = property.FindPropertyRelative("keyPoints");
            SerializedProperty bindValuesProperty = property.FindPropertyRelative("bindPointsValues");


            AnimationCurve curve = curveProperty.animationCurveValue;

            if (bindValuesProperty.boolValue)
            {
                curve = new AnimationCurve();
                
                for (int i = 0; i < pointsProperty.arraySize; i++)
                {
                    SerializedProperty pointProperty = pointsProperty.GetArrayElementAtIndex(i);
                    curve.AddKey(pointProperty.vector2Value.x, pointProperty.vector2Value.y);
                }
            }
            
            curveProperty.animationCurveValue = curve;
            
            EditorGUILayout.PropertyField(curveProperty, new GUIContent("Curve"));
            EditorGUILayout.PropertyField(bindValuesProperty, new GUIContent("Set Points From List"));
            
            if (bindValuesProperty.boolValue)
            {
                EditorGUILayout.PropertyField(pointsProperty, new GUIContent("Points"), true);
            }

            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}