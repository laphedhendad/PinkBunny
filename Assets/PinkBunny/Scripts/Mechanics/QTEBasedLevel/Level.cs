using Laphed.LevelEventBus;
using Laphed.Timer;
using UnityEngine;
using Zenject;

namespace Laphed.QTEBasedLevel
{
    public class Level: ILevel, IBuildableLevel, ILevelCompletedHandler, ILevelFailedHandler
    {
        private readonly IQteQueue qteQueue;
        private readonly IPlayerInput playerInput;
        private readonly IUpdatableTimer levelTimer;
        private readonly IAcceleratingTimer qteTimer;

        [Inject]
        public Level(
            IUpdatableTimer levelTimer,
            IAcceleratingTimer qteTimer,
            IQteQueue qteQueue,
            IPlayerInput playerInput
        )
        {
            this.levelTimer = levelTimer;
            this.qteQueue = qteQueue;
            this.playerInput = playerInput;
            this.qteTimer = qteTimer;
        }
        
        public void Start()
        {
            levelTimer.Start();
            ToNextQte();
            playerInput.Enable();
            playerInput.OnClick += ToNextQte;
        }

        public void SetLevelTime(float time)
        {
            levelTimer.SetDuration(time);
        }

        private void ToNextQte()
        {
            if (qteQueue.IsEmpty()) return;
            qteQueue.ActivateNextQuickTimeEvent();
        }

        public void SetQteQueue(QteQueueSetup qteQueueSetup)
        {
            qteQueue.SetTimerSettings(qteQueueSetup.timerSettings);
        }

        public void Fail()
        {
            playerInput.Disable();
            playerInput.OnClick -= ToNextQte;
            Debug.Log("Fail");
        }

        public void Complete()
        {
            
            Debug.Log("Complete");
        }

        public void OnLevelCompleted()
        {
            Complete();
        }

        public void OnLevelFailed()
        {
            Fail();
        }
    }
}