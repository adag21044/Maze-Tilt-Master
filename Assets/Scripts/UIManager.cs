using UnityEngine;
using TMPro; // Import TextMesh Pro namespace

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI gameStateText; // TextMesh Pro text element to display the game state

    private void Start()
    {
        // Subscribe to the game state change event
        GameManager.Instance.OnGameStateChange += UpdateUI;
        UpdateUI(GameManager.Instance.CurrentState); // Initialize the UI
    }

    private void OnDestroy()
    {
        // Unsubscribe from the game state change event
        GameManager.Instance.OnGameStateChange -= UpdateUI;
    }

    private void UpdateUI(GameState newState)
    {
        // Update the UI text based on the game state
        switch (newState)
        {
            case GameState.Start:
                gameStateText.text = "Game Started!";
                break;
            case GameState.Playing:
                gameStateText.text = "Guide the Ball to the Goal!";
                break;
            case GameState.End:
                gameStateText.text = "Congratulations! You Finished the Game.";
                break;
        }
    }
}
