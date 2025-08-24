using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    public float lifetime = 5f;
    public GameObject hitEffect;
    public AudioClip hitSound;
    
    private AudioSource audioSource;

    void Start()
    {
        // Destroy projectile after lifetime
        Destroy(gameObject, lifetime);
        
        // Setup audio
        if (hitSound != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = hitSound;
            audioSource.playOnAwake = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Play hit sound
        if (audioSource != null && hitSound != null)
        {
            audioSource.Play();
        }
        
        // Show hit effect
        if (hitEffect != null)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
        }
        
        // Check what we hit
        DestroyableTarget target = collision.gameObject.GetComponent<DestroyableTarget>();
        if (target != null)
        {
            target.OnHit();
        }
        
        FloatingOrb orb = collision.gameObject.GetComponent<FloatingOrb>();
        if (orb != null)
        {
            orb.OnHit();
        }
        
        Debug.Log($"Projectile hit: {collision.gameObject.name}");
        
        // Destroy projectile
        Destroy(gameObject, 0.1f); // Small delay for sound
    }
}
