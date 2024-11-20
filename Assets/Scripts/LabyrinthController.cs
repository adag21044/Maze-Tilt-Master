using UnityEngine;

public class LabyrinthController : MonoBehaviour
{
    private void Start()
    {
        // Subscribe to the game state change event
        GameManager.Instance.OnGameStateChange += HandleGameStateChange;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the game state change event
        GameManager.Instance.OnGameStateChange -= HandleGameStateChange;
    }

    private void HandleGameStateChange(GameState newState)
    {
        switch (newState)
        {
            case GameState.Start:
                Debug.Log("Game started!");
                break;
            case GameState.Playing:
                Debug.Log("Game is in progress!");
                break;
            case GameState.End:
                Debug.Log("Game ended!");
                break;
        }
    }
}
