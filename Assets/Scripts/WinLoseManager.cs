using System;
using System.Threading.Tasks;
using Levels;
using Zenject;

public class WinLoseManager : IInitializable
{
    [Inject] private LevelGenerator _levelGenerator;
    
    public void Initialize()
    {
        Card.RightCardChoosen += Win;
    }
    
    private async void Win()
    {
        await Task.Delay(TimeSpan.FromSeconds(1.5f));

        _levelGenerator.NextLevel();
    }
}