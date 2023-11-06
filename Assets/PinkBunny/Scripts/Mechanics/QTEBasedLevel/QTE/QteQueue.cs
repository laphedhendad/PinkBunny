using System.Collections.Generic;
using Laphed.Timer;
using Zenject;

namespace Laphed.QTEBasedLevel
{
    public class QteQueue: IQteQueue
    {
        private Queue<AcceleratingTimerSettings> timerSettingsQueue;
        private readonly IAcceleratingTimer timer;
        
        [Inject]
        public QteQueue(IAcceleratingTimer timer)
        {
            this.timer = timer;
        }

        public void SetTimerSettings(IEnumerable<AcceleratingTimerSettings> timerSettings)
        {
            timerSettingsQueue = new Queue<AcceleratingTimerSettings>(timerSettings);
        }
        
        public void ActivateNextQuickTimeEvent()
        {
            AcceleratingTimerSettings nextTimerSettings = timerSettingsQueue.Dequeue();
            timer.UpdateCurve(nextTimerSettings);
            timer.Start();
        }

        public bool IsEmpty()
        {
            return timerSettingsQueue.Count == 0;
        }
    }
}