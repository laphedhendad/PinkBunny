using Laphed.QTEBasedLevel;
using Laphed.Timer;
using UnityEngine;
using Zenject;

namespace Laphed.PinkBunny
{
    public class LevelInstaller: MonoInstaller
    {
        [SerializeField] private LevelConfig levelConfig;

        public override void InstallBindings()
        {
            BindTimers();
            BindLevel();
        }

        public override void Start()
        {
            BuildCurrentLevel();
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
        }

        private void BuildCurrentLevel()
        {
            IBuildableLevel buildableLevel = Container.Resolve<IBuildableLevel>();
            ILevelBuilder levelBuilder = Container.Resolve<ILevelBuilder>();
            levelBuilder.Build(buildableLevel, levelConfig);
            ILevel level = Container.Resolve<ILevel>();
            Container.Resolve<IPlayerInput>().OnClick += level.ToNextQte;
        }

        private void OnDisable()
        {
            ILevel level = Container.Resolve<ILevel>();
            Container.Resolve<IPlayerInput>().OnClick -= level.ToNextQte;
        }
    }
}