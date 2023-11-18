using UnityEngine;
using UnityEngine.InputSystem.UI;
using Zenject;
using Laphed.InterfacesEventBus;

namespace Laphed.PinkBunny
{
    public class ProjectContextMonoInstaller : MonoInstaller
    {
        [SerializeField] private InputSystemUIInputModule uiInputModule;

        public override void InstallBindings()
        {
            BindEventBus();
            BindInput();
        }

        public override void Start() => Container.Resolve<InputSchemeSwitch>();

        private void BindInput()
        {
            Container.Bind<InputSystemUIInputModule>().FromInstance(uiInputModule).AsSingle();
            Container.Bind<IPlayerInput>().To<PlayerInput>().AsSingle();
            Container.Bind<InputSchemeSwitch>().AsSingle();
        }

        private void BindEventBus() => Container.BindInterfacesTo<EventBus>().AsSingle();
    }
}