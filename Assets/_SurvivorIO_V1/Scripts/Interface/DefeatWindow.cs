using UnityEngine;
using UnityEngine.UI;

public class DefeatWindow : Window
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button returnToMainMenuButton;

    public override void Initialize()
    {
        restartButton.onClick.AddListener(OnRestartClicked);
        returnToMainMenuButton.onClick.AddListener(OnReturnToMainMenuClicked);
    }

    private void OnReturnToMainMenuClicked()
    {
        Hide(true);
        GameManager.Instance.WindowsService.ShowWindow<MainMenuWindow>(false);
    }

    private void OnRestartClicked()
    {
        Hide(true);
        GameManager.Instance.WindowsService.ShowWindow<GameplayWindow>(false);
        GameManager.Instance.StartGame();
    }
}