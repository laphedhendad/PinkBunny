using Laphed.Horror;
using Laphed.QTEBasedLevel;
using Laphed.Timer;
using UnityEngine;
using UnityEngine.Timeline;
using Zenject;

namespace Laphed.PinkBunny
{
    public class LevelInstaller: MonoInstaller
    {
        [SerializeField] private LevelConfig levelConfig;
        [SerializeField] private Cutscenes cutscenes;

        public override void InstallBindings()
        {
            BindCutscenes();
            BindTimers();
            BindLevel();
            BindLevelEventsHandlers();
        }

        public override void Start()
        {
            BindInputToLevel();
            ResolveLevelEventsHandlers();
        }

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
            Container.BindInterfacesAndSelfTo<Level>().AsSingle();
            Container.BindInterfacesTo<LevelBuilder>().AsSingle();
            Container.Bind<LevelConfig>().FromInstance(levelConfig);
            Container.Bind<ILevelEntryPoint>().To<LevelEntryPoint>().AsSingle();
        }

        private void BindCutscenes()
        {
            Container.Bind<Cutscenes>().FromInstance(cutscenes).AsSingle();
            Container.BindFactory<TimelineAsset, Screamer, Screamer.Factory>();
        }

        private void BindLevelEventsHandlers()
        {
            Container.Bind<LevelCompletedHandler>().AsSingle();
            Container.Bind<LevelFailedHandler>().AsSingle();
        }

        private void BindInputToLevel()
        {
            ILevel level = Container.Resolve<ILevel>();
            Container.Resolve<IPlayerInput>().OnClick += level.ToNextQte;
        }
        
        private void ResolveLevelEventsHandlers()
        {
            Container.Resolve<LevelCompletedHandler>();
            Container.Resolve<LevelFailedHandler>();
        }
    }
}