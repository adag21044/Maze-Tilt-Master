using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField]
    private LightFollow lightFollow; // The script controlling the light's behavior

    private void Start()
    {
        // Subscribe to the target change event
        GameManager.Instance.OnTargetChange += HandleTargetChange;

        // Set the initial target as the ball
        HandleTargetChange(FindObjectOfType<BallController>().transform);
    }

    private void OnDestroy()
    {
        // Unsubscribe from the target change event
        GameManager.Instance.OnTargetChange -= HandleTargetChange;
    }

    private void HandleTargetChange(Transform newTarget)
    {
        // Update the light's target
        lightFollow.SetTarget(newTarget);
    }
}
