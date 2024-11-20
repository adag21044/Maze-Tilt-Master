using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField]
    private LightFollow lightFollow; // Işığı yöneten script

    private void Start()
    {
        // GameManager'dan hedef değişim olayını dinle
        GameManager.Instance.OnTargetChange += HandleTargetChange;

        // Oyunun başlangıcında topu hedef olarak ayarla
        HandleTargetChange(FindObjectOfType<BallController>().transform);
    }

    private void OnDestroy()
    {
        // Olaydan aboneliği kaldır
        GameManager.Instance.OnTargetChange -= HandleTargetChange;
    }

    private void HandleTargetChange(Transform newTarget)
    {
        // Işığın yeni hedefini ayarla
        lightFollow.SetTarget(newTarget);
    }
}
