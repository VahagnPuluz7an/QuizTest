using UnityEngine;
using Zenject;

namespace Levels
{
    public class LevelsIsntaller : MonoInstaller
    {
        [SerializeField] private LevelsData levelsData;
        
        public override void InstallBindings()
        {
            Container.Bind<LevelsData>().FromInstance(levelsData);
            Container.Bind<HintText>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelGenerator>().AsSingle();
        }
    }
}