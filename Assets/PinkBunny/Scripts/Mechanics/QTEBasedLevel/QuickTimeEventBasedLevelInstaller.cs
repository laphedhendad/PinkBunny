using Laphed.Mechanics.LevelEventBus;
using Zenject;

namespace Laphed.Mechanics.QTEBasedLevel
{
    public class QuickTimeEventBasedLevelInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            BindEventBus();
        }

        private void BindEventBus()
        {
            Container.BindInterfacesTo<EventBus>().AsSingle();
        }
    }
}