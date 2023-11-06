using UnityEngine;
using UnityEngine.Timeline;

namespace Laphed.PinkBunny
{
    [CreateAssetMenu(fileName = "Cutscenes", menuName = "Config/Cutscenes")]
    public class Cutscenes: ScriptableObject
    {
        public TimelineAsset levelFailedScreamer;
    }
}