using Laphed.CoroutineProvider;
using Laphed.EventBus;
using Laphed.QTEBasedLevel;
using UnityEngine;
using Zenject;

public class ProjectContextMonoInstaller : MonoInstaller
{
    [SerializeField] private CoroutineProvider coroutineProvider;
    private InputSchemeSwitcher inputSchemeSwitcher;
    public override void InstallBindings()
    {
        BindEventBus();
        BindUtils();
        BindInput();
    }

    public override void Start()
    {
        inputSchemeSwitcher = Container.Resolve<InputSchemeSwitcher>();
    }

    private void BindUtils()
    {
        Container.Bind<ICoroutineProvider>().FromInstance(coroutineProvider).AsSingle();
    }

    private void BindInput()
    {
        Container.Bind<IPlayerInput>().To<PlayerInput>().AsSingle();
        Container.Bind<InputSchemeSwitcher>().AsSingle();
    }
    
    private void BindEventBus()
    {
        Container.BindInterfacesTo<EventBus>().AsSingle();
    }
}