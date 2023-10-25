using Laphed.EventBus;

namespace Laphed.QTEBasedLevel
{
    public struct LevelStarted: IEvent{}
    public struct LevelCompleted: IEvent{}
    public struct LevelFailed: IEvent{}
}