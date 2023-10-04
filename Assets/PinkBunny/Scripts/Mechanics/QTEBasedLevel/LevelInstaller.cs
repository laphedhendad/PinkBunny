using Laphed.LevelEventBus;
using Laphed.QTEBasedLevel.UI;
using Laphed.Timer;
using UnityEngine;
using Zenject;

namespace Laphed.QTEBasedLevel
{
    public class LevelInstaller: MonoInstaller
    {
        [SerializeField] private LevelConfig levelConfig;
        
        public override void InstallBindings()
        {
            BindInput();
            BindEventBus();
            BindTimers();
            BindLevel();
        }

        public override void Start()
        {
            RegisterGlobalEvents();
            BindUI();
            BuildCurrentLevel();
        }

        private void BindInput() => Container.Bind<IPlayerInput>().To<PlayerInput>().AsSingle();
        
        private void BindEventBus() => Container.BindInterfacesTo<EventBus>().AsSingle();

        private void BindTimers()
        {
            Container.BindIFactory<AcceleratingTimerFactory>().AsSingle();
            Container.BindIFactory<UpdatableTimerFactory>().AsSingle();
            Container.Bind<IAcceleratingTimer>().FromFactory<AcceleratingTimerFactory>().AsSingle();
            Container.Bind<IUpdatableTimer>().FromFactory<UpdatableTimerFactory>().AsSingle();
        }

        private void BindLevel()
        {
            Container.Bind<IQteQueue>().To<QteQueue>().AsSingle();
            Container.Bind<LevelExitPointsTracker>().AsSingle();
            Container.BindInterfacesAndSelfTo<Level>().AsSingle();
            Container.BindInterfacesTo<LevelBuilder>().AsSingle();
        }

        private void RegisterGlobalEvents()
        {
            Container.Resolve<LevelExitPointsTracker>();
            var eventBus = Container.Resolve<IExitPointEventsRegistrar>();
            var level = Container.Resolve<Level>();
            eventBus.SubscribeOnLevelCompleted(level);
            eventBus.SubscribeOnLevelFailed(level);
        }

        private void BindUI()
        {
            UIBinder uiBinder = Container.Resolve<UIBinder>();
            ITimer levelTimer = Container.Resolve<IUpdatableTimer>();
            ITimer qteTimer = Container.Resolve<IAcceleratingTimer>();
            ILevel level = Container.Resolve<ILevel>();
            
            uiBinder.Bind(levelTimer, qteTimer, level);
        }
        
        private void BuildCurrentLevel()
        {
            IBuildableLevel level = Container.Resolve<IBuildableLevel>();
            ILevelBuilder levelBuilder = Container.Resolve<ILevelBuilder>();
            levelBuilder.Build(level, levelConfig);
        }
    }
}