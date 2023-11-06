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
            ILevelEntryPoint levelEntryPoint = Container.Resolve<ILevelEntryPoint>();

            uiBinder.Bind(levelTimer, qteTimer, levelEntryPoint);
        }
    }
}