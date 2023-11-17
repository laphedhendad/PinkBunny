using System.Linq;
using Cysharp.Threading.Tasks;
using Laphed.PinkBunny.UI;
using Laphed.QTEBasedLevel;
using Zenject;

namespace Laphed.PinkBunny
{
    public class LevelEntryPoint: ILevelEntryPoint
    {
        private readonly IUiModeSwitch uiModeSwitch;
        private readonly IBuildableLevel level;
        private readonly LevelConfig levelConfig;
        private readonly ILevelBuilder levelBuilder;
        private readonly IBatteriesPool batteriesPool;

        [Inject]
        public LevelEntryPoint(IUiModeSwitch uiModeSwitch, IBuildableLevel level, LevelConfig levelConfig, ILevelBuilder levelBuilder, IBatteriesPool batteriesPool)
        {
            this.uiModeSwitch = uiModeSwitch;
            this.level = level;
            this.levelConfig = levelConfig;
            this.levelBuilder = levelBuilder;
            this.batteriesPool = batteriesPool;
        }
        
        public async void StartLevel()
        {
            UniTask buildLevelTask = BuildCurrentLevel();
            UniTask switchUiTask = uiModeSwitch.Switch();
            await UniTask.WhenAll(buildLevelTask, switchUiTask);
            level.Start();
        }
        
        private async UniTask BuildCurrentLevel()
        {
            await UniTask.RunOnThreadPool(()=>levelBuilder.Build(level, levelConfig));
            batteriesPool.SetBatteriesAmount(levelConfig.GetTimerSettings().Count());
        }
    }
}