using Zenject;

public class GameLoopInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<WinLoseManager>().AsSingle();
        Container.Bind<LevelsRestarter>().FromComponentInHierarchy().AsSingle();
    }
}