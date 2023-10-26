using Laphed.CoroutineProvider;
using Laphed.EventBus;
using Laphed.QTEBasedLevel;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using Zenject;

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

    public override void Start() => Container.Resolve<InputSchemeSwitcher>();

    private void BindUtils() => Container.Bind<ICoroutineProvider>().FromInstance(coroutineProvider).AsSingle();

    private void BindInput()
    {
        Container.Bind<InputSystemUIInputModule>().FromInstance(uiInputModule).AsSingle();
        Container.Bind<IPlayerInput>().To<PlayerInput>().AsSingle();
        Container.Bind<InputSchemeSwitcher>().AsSingle();
    }
    
    private void BindEventBus() => Container.BindInterfacesTo<EventBus>().AsSingle();
}