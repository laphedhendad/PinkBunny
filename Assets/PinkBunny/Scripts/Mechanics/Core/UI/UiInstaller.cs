using Laphed.QTEBasedLevel;
using Laphed.Timers;
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
            ITimer levelTimer = Container.ResolveId<ITimer>(TimerType.Level);
            ITimer qteTimer = Container.ResolveId<ITimer>(TimerType.Qte);
            ILevelEntryPoint levelEntryPoint = Container.Resolve<ILevelEntryPoint>();
            IBatteriesPool batteriesPool = Container.Resolve<IBatteriesPool>();

            uiBinder.BindLevelTimer(levelTimer);
            uiBinder.BindQteTimer(qteTimer);
            uiBinder.BindStartButton(levelEntryPoint);
            uiBinder.BindBatteries(batteriesPool);
        }
    }
}