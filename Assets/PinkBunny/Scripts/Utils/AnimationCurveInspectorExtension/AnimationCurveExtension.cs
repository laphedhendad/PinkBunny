using System;
using System.Collections.Generic;
using UnityEngine;

namespace Laphed.AnimationCurveInspectorExtension
{
    [Serializable]
    public class AnimationCurveExtension
    {
        public AnimationCurve curve;
#if UNITY_EDITOR
        [SerializeField] private List<Vector2> keyPoints;
#endif
    }
}