using UnityEngine;

public class DestroyableTarget : MonoBehaviour
{
    [Header("Target Settings")]
    public GameObject destroyEffect;
    public AudioClip destroySound;
    public GameManagerSimple gameManager;
    public bool isCRTMonitor7 = false;
    
    private AudioSource audioSource;
    private bool isDestroyed = false;

    void Start()
    {
        if (destroySound != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = destroySound;
            audioSource.playOnAwake = false;
        }
    }

    public void OnHit()
    {
        if (isDestroyed) return;
        
        isDestroyed = true;
        
        // Play destroy sound
        if (audioSource != null && destroySound != null)
        {
            audioSource.Play();
        }
        
        // Show destroy effect
        if (destroyEffect != null)
        {
            GameObject effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(effect, 3f);
        }
        
        // Notify game manager if this is CRT Monitor 7
        if (isCRTMonitor7 && gameManager != null)
        {
            gameManager.OnCRTMonitorDestroyed();
        }
        
        // Destroy this object
        Destroy(gameObject, 0.5f); // Delay for sound/effects
    }
}
