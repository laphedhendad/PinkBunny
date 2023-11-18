using Laphed.Horror;
using Laphed.QTEBasedLevel;
using Laphed.Timers;
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
            Container.Bind<ITimer>().WithId(TimerType.Level).FromInstance(new Timer());
            Container.Bind<IAcceleratingTimer>().WithId(TimerType.Qte).FromInstance(new AcceleratingTimer());
        }

        private void BindLevel()
        {
            Container.Bind<IQteQueue>().To<QteQueue>().AsSingle();
            Container.BindInterfacesAndSelfTo<Level>().AsSingle();
            Container.BindInterfacesTo<LevelBuilder>().AsSingle();
            Container.Bind<LevelConfig>().FromInstance(levelConfig);
            Container.Bind<ILevelEntryPoint>().To<LevelEntryPoint>().AsSingle();
            Container.BindInterfacesTo<BatteriesPool>().AsSingle();
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
            IBatteriesPool batteriesPool = Container.Resolve<IBatteriesPool>();
            Container.Resolve<IPlayerInput>().OnClick += batteriesPool.TryUseBattery;
        }
        
        private void ResolveLevelEventsHandlers()
        {
            Container.Resolve<LevelCompletedHandler>();
            Container.Resolve<LevelFailedHandler>();
        }
    }
}