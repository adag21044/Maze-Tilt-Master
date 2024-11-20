using UnityEngine;

public class LightFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target; // Takip edilecek obje (Top)

    [SerializeField]
    private Vector3 offset = new Vector3(0, 5, 0); // Işığın topa göre konumu

    private void LateUpdate()
    {
        if (target != null)
        {
            // Işığı topun pozisyonuyla eşitle ve ofset uygula
            transform.position = target.position + offset;
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget; // Takip edilecek yeni hedefi belirle
    }
}
