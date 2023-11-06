using Cysharp.Threading.Tasks;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using Zenject;

namespace Laphed.Horror
{
    public class Screamer: IScreamer
    {
        private readonly PlayableDirector cutsceneDirector;
        private readonly TimelineAsset timelineAsset;

        [Inject]
        public Screamer(PlayableDirector cutsceneDirector, TimelineAsset timelineAsset)
        {
            this.cutsceneDirector = cutsceneDirector;
            this.timelineAsset = timelineAsset;
        }
        
        public async UniTask Show()
        {
            cutsceneDirector.playableAsset = timelineAsset;
            cutsceneDirector.Play();
            await UniTask.Delay((int)(timelineAsset.duration * 1000));
        }

        public class Factory : PlaceholderFactory<TimelineAsset, IScreamer>
        {
        }
    }
}