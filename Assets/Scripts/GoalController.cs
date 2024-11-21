using UnityEngine;

public class GoalController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Goal reached!");
            LevelManager.Instance.LoadNextLevel(); // Load the next level
        }
    }
}
