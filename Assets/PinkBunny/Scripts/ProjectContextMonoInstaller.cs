using Laphed.CoroutineProvider;
using UnityEngine;
using Zenject;

public class ProjectContextMonoInstaller : MonoInstaller
{
    [SerializeField] private CoroutineProvider coroutineProvider;
    public override void InstallBindings()
    {
        BindUtils();
    }

    private void BindUtils()
    {
        Container.Bind<CoroutineProvider>().FromInstance(coroutineProvider).AsSingle();
    }
}