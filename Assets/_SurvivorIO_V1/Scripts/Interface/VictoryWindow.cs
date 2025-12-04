using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VictoryWindow : Window
{
    [SerializeField] private Button continueButton;
    [SerializeField] private TMP_Text recordText;
    [SerializeField] private TMP_Text newRecordText;

    public override void Initialize()
    {
        continueButton.onClick.AddListener(OnContinueClicked);
    }

    protected override void OpenStart()
    {
        base.OpenStart();

        recordText.text = GameManager.Instance.ScoreSystem.Score.ToString();
        newRecordText.gameObject.SetActive(GameManager.Instance.ScoreSystem.IsNewScoreRecord);
    }

    private void OnContinueClicked()
    {
        Hide(true);
        GameManager.Instance.WindowsService.ShowWindow<MainMenuWindow>(false);
    }
}