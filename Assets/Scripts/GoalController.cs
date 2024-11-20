using UnityEngine;

public class GoalController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Goal reached!");
            GameManager.Instance.ChangeState(GameState.End); // Change the game state to End
        }
    }
}
