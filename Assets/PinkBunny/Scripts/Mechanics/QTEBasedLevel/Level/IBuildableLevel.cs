namespace Laphed.QTEBasedLevel
{
    public interface IBuildableLevel: ILevel
    {
        void SetLevelTime(float time);
        void SetQteQueue(QteQueueSetup qteQueueSetup);
    }
}