using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] mazes; // Array of maze GameObjects

    [SerializeField]
    private LevelData[] levelData; // Array of LevelData ScriptableObjects

    [SerializeField]
    private Transform goal; // Reference to the goal transform

    [SerializeField]
    private Transform ball; // Reference to the ball transform

    private int currentLevel = 0; // Track the current level

    private Vector3 initialBallPosition = new Vector3(0, 0.4890001f, 0); // Initial position for the ball

    public static LevelManager Instance { get; private set; } // Singleton Instance

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializeLevels(); // Ensure only the first maze is active at the start
        ResetBallPosition(); // Place the ball at the initial position
        SetGoalPosition(); // Set the goal's initial position
    }

    private void InitializeLevels()
    {
        // Activate the first maze and deactivate all others
        for (int i = 0; i < mazes.Length; i++)
        {
            mazes[i].SetActive(i == 0); // Activate only the first maze
        }
    }

    /// <summary>
    /// Progresses to the next level, if available.
    /// </summary>
    public void LoadNextLevel()
    {
        if (currentLevel < mazes.Length - 1)
        {
            // Deactivate the current maze
            mazes[currentLevel].SetActive(false);

            // Increment level and activate the next maze
            currentLevel++;
            mazes[currentLevel].SetActive(true);

            Debug.Log($"Level {currentLevel + 1} activated.");

            // Reset the ball's position
            ResetBallPosition();

            // Set the goal's position for the new level
            SetGoalPosition();
        }
        else
        {
            Debug.Log("You won. Game completed!");
        }
    }

    /// <summary>
    /// Resets the ball to its initial position.
    /// </summary>
    private void ResetBallPosition()
    {
        if (ball != null)
        {
            ball.position = initialBallPosition; // Reset the position
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero; // Stop any ongoing movement
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // Stop any ongoing rotation
        }
        else
        {
            Debug.LogWarning("Ball reference is missing in LevelManager!");
        }
    }

    /// <summary>
    /// Sets the goal position for the current level using the LevelData ScriptableObject.
    /// </summary>
    private void SetGoalPosition()
    {
        if (goal != null && currentLevel < levelData.Length)
        {
            goal.position = levelData[currentLevel].goalPosition;
            Debug.Log($"Goal position set to: {goal.position}");
        }
        else
        {
            Debug.LogWarning("Goal reference or LevelData is missing!");
        }
    }

    /// <summary>
    /// Resets the level system back to the first level.
    /// </summary>
    public void ResetLevels()
    {
        // Deactivate all mazes
        foreach (var maze in mazes)
        {
            maze.SetActive(false);
        }

        // Reset to the first maze
        currentLevel = 0;
        mazes[currentLevel].SetActive(true);

        Debug.Log("Levels reset. Back to Level 1.");

        // Reset the ball's position
        ResetBallPosition();

        // Set the goal's position for the first level
        SetGoalPosition();
    }
}
