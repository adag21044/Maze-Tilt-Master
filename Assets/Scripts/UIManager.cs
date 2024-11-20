using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text gameStateText;

    private void Start()
    {
        GameManager.Instance.OnGameStateChange += UpdateUI;
        UpdateUI(GameManager.Instance.CurrentState);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameStateChange -= UpdateUI;
    }

    private void UpdateUI(GameState newState)
    {
        switch (newState)
        {
            case GameState.Start:
                gameStateText.text = "Oyuna Başlamak için Dokun!";
                break;
            case GameState.Playing:
                gameStateText.text = "Topu Hedefe Ulaştır!";
                break;
            case GameState.End:
                gameStateText.text = "Tebrikler! Oyunu Bitirdiniz.";
                break;
        }
    }
}
