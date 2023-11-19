using System.Collections.Generic;

namespace Laphed.QTEBasedLevel
{
    public interface IBuildableLevel: ILevel
    {
        void SetLevelTime(float time);
        void SetQteQueue(IEnumerable<QteData> qteQueueSetup);
    }
}