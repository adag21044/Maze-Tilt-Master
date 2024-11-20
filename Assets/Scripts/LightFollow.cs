using UnityEngine;

public class LightFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target; // The object to follow (e.g., the ball)

    [SerializeField]
    private Vector3 offset = new Vector3(0, 5, 0); // The offset position relative to the target

    private void LateUpdate()
    {
        if (target != null)
        {
            // Update the light's position to follow the target with the specified offset
            transform.position = target.position + offset;
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget; // Update the target to follow
    }
}
