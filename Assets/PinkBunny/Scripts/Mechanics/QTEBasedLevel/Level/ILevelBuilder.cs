namespace Laphed.QTEBasedLevel
{
    public interface ILevelBuilder
    {
        void Build(IBuildableLevel level, LevelConfig levelConfig);
    }
}