namespace Laphed.QTEBasedLevel
{
    public interface IBuildableLevel
    {
        void SetLevelTime(float time);
        void SetQteQueue(QteQueueSetup qteQueueSetup);
    }
}