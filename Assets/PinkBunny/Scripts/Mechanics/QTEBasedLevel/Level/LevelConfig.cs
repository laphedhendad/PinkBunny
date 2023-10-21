using System.Collections.Generic;
using Laphed.AnimationCurveInspectorExtension;
using Laphed.Timer;
using UnityEngine;

namespace Laphed.QTEBasedLevel
{
    [CreateAssetMenu(fileName = "Level", menuName = "Config/LevelConfig")]
    public class LevelConfig: ScriptableObject
    {
        [SerializeField] private List<AnimationCurveExtension> acceleratingTimerSettings;
        public int levelTimerInSeconds;
        
        public IEnumerable<AcceleratingTimerSettings> GetTimerSettings()
        {
            AcceleratingTimerSettings[] timerSettings = new AcceleratingTimerSettings[acceleratingTimerSettings.Count];

            for (int i = 0; i < timerSettings.Length; i++)
            {
                timerSettings[i] = new AcceleratingTimerSettings()
                {
                    curve = acceleratingTimerSettings[i].curve
                };
            }
            
            return timerSettings;
        }
    }
}