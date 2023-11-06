using Laphed.CoroutinesProvider;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using Zenject;
using Laphed.InterfacesEventBus;
using Laphed.PinkBunny;

namespace Laphed.PinkBunny
{
    public class ProjectContextMonoInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineProvider coroutineProvider;
        [SerializeField] private InputSystemUIInputModule uiInputModule;

        public override void InstallBindings()
        {
            BindEventBus();
            BindUtils();
            BindInput();
        }

        public override void Start() => Container.Resolve<InputSchemeSwitch>();

        private void BindUtils() => Container.Bind<ICoroutineProvider>().FromInstance(coroutineProvider).AsSingle();

        private void BindInput()
        {
            Container.Bind<InputSystemUIInputModule>().FromInstance(uiInputModule).AsSingle();
            Container.Bind<IPlayerInput>().To<PlayerInput>().AsSingle();
            Container.Bind<InputSchemeSwitch>().AsSingle();
        }

        private void BindEventBus() => Container.BindInterfacesTo<EventBus>().AsSingle();
    }
}