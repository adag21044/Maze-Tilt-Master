using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton Instance
    public static GameManager Instance { get; private set; }

    // Game State Change Event
    public delegate void GameStateChange(GameState newState);
    public event GameStateChange OnGameStateChange;

    // Target Change Event (Observer Pattern)
    public delegate void TargetChange(Transform newTarget);
    public event TargetChange OnTargetChange;

    // Current Game State
    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        // Singleton Pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Oyunun sahneler arasında devam etmesini sağlar
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Oyunu başlatma durumuna geç
        ChangeState(GameState.Start);
    }

    /// <summary>
    /// Oyun durumunu değiştirir ve ilgili event'i tetikler.
    /// </summary>
    /// <param name="newState">Yeni oyun durumu</param>
    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
        Debug.Log($"Game State Changed to: {newState}");

        // Durum değişikliği olayını tetikle
        OnGameStateChange?.Invoke(newState);
    }

    /// <summary>
    /// Takip edilecek hedefi değiştirir ve ilgili event'i tetikler.
    /// </summary>
    /// <param name="newTarget">Yeni hedef (Transform)</param>
    public void ChangeTarget(Transform newTarget)
    {
        Debug.Log($"Target Changed to: {newTarget.name}");

        // Hedef değişikliği olayını tetikle
        OnTargetChange?.Invoke(newTarget);
    }
}

/// <summary>
/// Oyun durumlarının tanımlandığı enum.
/// </summary>
public enum GameState
{
    Start,    // Oyun başlangıç durumunda
    Playing,  // Oyun oynanıyor
    End       // Oyun bitti
}
