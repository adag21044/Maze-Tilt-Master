using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public delegate void GameStateChange(GameState newState);
    public event GameStateChange OnGameStateChange;

    // Define the OnTargetChange event for target updates (Observer Pattern)
    public delegate void TargetChange(Transform newTarget);
    public event TargetChange OnTargetChange;

    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ChangeState(GameState.Start);
    }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
        Debug.Log($"Game State Changed to: {newState}");
        OnGameStateChange?.Invoke(newState);
    }

    /// <summary>
    /// Trigger the OnTargetChange event when the target changes.
    /// </summary>
    /// <param name="newTarget">The new target to be followed.</param>
    public void ChangeTarget(Transform newTarget)
    {
        Debug.Log($"Target Changed to: {newTarget.name}");
        OnTargetChange?.Invoke(newTarget);
    }

    public void TriggerNextLevel()
    {
        LevelManager.Instance.LoadNextLevel();
        ChangeState(GameState.Playing);
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