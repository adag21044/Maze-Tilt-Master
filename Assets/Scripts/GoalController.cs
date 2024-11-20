using UnityEngine;

public class GoalController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Hedefe ulaşıldı!");
            GameManager.Instance.ChangeState(GameState.End);
        }
    }
}
