using DG.Tweening;
using Levels;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelsRestarter : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private Button restartButton;

    [Inject] private LevelGenerator _generator;

    public bool Restarting { get; private set; }

    private void Awake()
    {
        LevelGenerator.LevelsEnded += EnableRestartButton;
        restartButton.onClick.AddListener(Restart);
    }

    private void OnDestroy()
    {
        LevelGenerator.LevelsEnded -= EnableRestartButton;
        restartButton.onClick.RemoveAllListeners();
    }

    private void EnableRestartButton()
    {
        Restarting = true;
        restartButton.gameObject.SetActive(true);
    }
        
    private void Restart()
    {
        restartButton.gameObject.SetActive(false);
        
        LevelsPrefsData.CurrentLevelIndex = 0;
        LevelsPrefsData.LastAnswerIndex = -1;

        fadeImage.DOFade(0.95f, 0.5f).onComplete += () =>
        {
            _generator.RestartLevel();
            Restarting = false;
            
            fadeImage.DOFade(0, 0.5f);
        };
    }
}