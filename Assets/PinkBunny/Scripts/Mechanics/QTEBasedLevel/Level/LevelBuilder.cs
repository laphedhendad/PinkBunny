namespace Laphed.QTEBasedLevel
{
    public class LevelBuilder: ILevelBuilder
    {
        public void Build(IBuildableLevel level, LevelConfig levelConfig)
        {
            level.SetLevelTime(levelConfig.levelTimerInSeconds);

            level.SetQteQueue(levelConfig.GetQteSetup());
        }
    }
}