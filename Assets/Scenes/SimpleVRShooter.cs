using UnityEngine;

public class SimpleVRShooter : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject projectilePrefab;
    public Transform shootPoint; // Assign controller tip or create empty child object
    public float projectileSpeed = 20f;
    public AudioClip shootSound;
    
    [Header("Controller Settings")]
    public bool isRightController = true; // Set to false for left controller
    
    private AudioSource audioSource;
    private bool triggerPressed = false;

    void Start()
    {
        // Add audio source for shoot sound
        if (shootSound != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = shootSound;
            audioSource.playOnAwake = false;
        }
    }

    void Update()
    {
        HandleShooting();
    }

    void HandleShooting()
    {
        // Get trigger input based on controller
        bool currentTrigger = isRightController ? 
            OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) : 
            OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
            
        // Shoot on trigger press (not hold)
        if (currentTrigger && !triggerPressed)
        {
            triggerPressed = true;
            Shoot();
        }
        else if (!currentTrigger)
        {
            triggerPressed = false;
        }
    }

    void Shoot()
    {
        if (projectilePrefab == null || shootPoint == null) return;

        // Create projectile
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        
        // Add velocity to projectile
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = shootPoint.forward * projectileSpeed;
        }

        // Play shoot sound
        if (audioSource != null && shootSound != null)
        {
            audioSource.Play();
        }

        Debug.Log("Projectile fired!");
    }
}
