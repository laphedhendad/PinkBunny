using Laphed.QTEBasedLevel;
using Laphed.Timer;
using Zenject;

namespace Laphed.PinkBunny.UI
{
    public class UiInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
        }

        public override void Start()
        {
            BindUi();
        }

        private void BindUi()
        {
            UiBinder uiBinder = Container.Resolve<UiBinder>();
            ITimer levelTimer = Container.Resolve<IUpdatableTimer>();
            ITimer qteTimer = Container.Resolve<IAcceleratingTimer>();
            ILevel level = Container.Resolve<ILevel>();

            uiBinder.Bind(levelTimer, qteTimer, level);
        }
    }
}