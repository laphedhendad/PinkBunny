using System.Collections.Generic;
using UnityEngine;

namespace Laphed.QTEBasedLevel
{
    [CreateAssetMenu(fileName = "Level", menuName = "Config/LevelConfig")]
    public class LevelConfig: ScriptableObject
    {
        [SerializeField] private List<QteData> qte;
        public int levelTimerInSeconds;
        
        public IEnumerable<QteData> GetQteSetup() => qte;
    }
}