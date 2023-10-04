namespace Laphed.QTEBasedLevel
{
    public class LevelBuilder: ILevelBuilder
    {
        public void Build(IBuildableLevel level, LevelConfig levelConfig)
        {
            level.SetLevelTime(levelConfig.levelTimerInSeconds);
            
            QteQueueSetup qteQueueSetup = new QteQueueSetup()
            {
                timerSettings = levelConfig.GetTimerSettings()
            };
            
            level.SetQteQueue(qteQueueSetup);
        }
    }
}