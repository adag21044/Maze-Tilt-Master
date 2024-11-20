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
            DontDestroyOnLoad(gameObject); // Ensure this object persists across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Set the initial game state
        ChangeState(GameState.Start);
    }

    /// <summary>
    /// Changes the current game state and triggers the event.
    /// </summary>
    /// <param name="newState">The new game state.</param>
    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
        Debug.Log($"Game State Changed to: {newState}");

        // Trigger the game state change event
        OnGameStateChange?.Invoke(newState);
    }

    /// <summary>
    /// Changes the target to be followed and triggers the event.
    /// </summary>
    /// <param name="newTarget">The new target (Transform).</param>
    public void ChangeTarget(Transform newTarget)
    {
        Debug.Log($"Target Changed to: {newTarget.name}");

        // Trigger the target change event
        OnTargetChange?.Invoke(newTarget);
    }
}

/// <summary>
/// Enum representing the different game states.
/// </summary>
public enum GameState
{
    Start,    // Game is at the start state
    Playing,  // Game is in the playing state
    End       // Game has ended
}
