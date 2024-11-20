using UnityEngine;

public class LabyrinthController : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.OnGameStateChange += HandleGameStateChange;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameStateChange -= HandleGameStateChange;
    }

    private void HandleGameStateChange(GameState newState)
    {
        switch (newState)
        {
            case GameState.Start:
                Debug.Log("Oyun başladı!");
                break;
            case GameState.Playing:
                Debug.Log("Oyun oynanıyor!");
                break;
            case GameState.End:
                Debug.Log("Oyun bitti!");
                break;
        }
    }
}
