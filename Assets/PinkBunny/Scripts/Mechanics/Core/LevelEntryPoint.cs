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

        [Inject]
        public LevelEntryPoint(IUiModeSwitch uiModeSwitch, IBuildableLevel level, LevelConfig levelConfig, ILevelBuilder levelBuilder)
        {
            this.uiModeSwitch = uiModeSwitch;
            this.level = level;
            this.levelConfig = levelConfig;
            this.levelBuilder = levelBuilder;
        }
        
        public async void StartLevel()
        {
            UniTask buildLevelTask = UniTask.RunOnThreadPool(BuildCurrentLevel);
            UniTask switchUiTask = uiModeSwitch.Switch();
            await UniTask.WhenAll(buildLevelTask, switchUiTask);
            level.Start();
        }
        
        private void BuildCurrentLevel() => levelBuilder.Build(level, levelConfig);
    }
}