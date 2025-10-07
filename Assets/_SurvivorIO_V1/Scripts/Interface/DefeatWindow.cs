using UnityEngine;
using UnityEngine.UI;

public class DefeatWindow : Window
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button returnToMainMenuButton;

    public override void Initialize()
    {
        restartButton.onClick.AddListener(OnRestartButtonClicked);
        returnToMainMenuButton.onClick.AddListener(OnReturnToMainMenuButtonClicked);
    }

    public void OnReturnToMainMenuButtonClicked()
    {
        Hide(true);
        GameManager.Instance.WindowsService.ShowWindow<MainMenuWindow>(false);
    }

    public void OnRestartButtonClicked()
    {
        Hide(true);
        GameManager.Instance.WindowsService.ShowWindow<GameplayWindow>(false);
        GameManager.Instance.StartGame();
    }
}