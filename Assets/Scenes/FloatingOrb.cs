using UnityEngine;

public class FloatingOrb : MonoBehaviour
{
    [Header("Orb Settings")]
    public bool isKeyOrb = false;
    public GameObject destroyEffect;
    public AudioClip hitSound;
    
    [Header("Floating Animation")]
    public float floatSpeed = 2f;
    public float floatHeight = 0.5f;
    public float rotationSpeed = 50f;
    
    private GameManagerSimple gameManager;
    private AudioSource audioSource;
    private bool hasBeenHit = false;
    private Vector3 startPosition;
    private float randomOffset;

    void Start()
    {
        // Add audio source if hit sound is assigned
        if (hitSound != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = hitSound;
            audioSource.playOnAwake = false;
        }
        
        // Add a collider if it doesn't exist
        if (GetComponent<Collider>() == null)
        {
            SphereCollider collider = gameObject.AddComponent<SphereCollider>();
            collider.isTrigger = false;
        }
        
        // Add rigidbody for physics
        if (GetComponent<Rigidbody>() == null)
        {
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false; // We'll handle floating manually
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        
        // Store starting position and random offset for variety
        startPosition = transform.position;
        randomOffset = Random.Range(0f, 2f * Mathf.PI);
    }

    void Update()
    {
        // Floating animation
        FloatAnimation();
        
        // Rotation animation
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void FloatAnimation()
    {
        // Calculate new Y position using sine wave
        float newY = startPosition.y + Mathf.Sin((Time.time * floatSpeed) + randomOffset) * floatHeight;
        
        // Apply the floating motion
        Vector3 newPosition = new Vector3(transform.position.x, newY, transform.position.z);
        transform.position = newPosition;
    }

    public void Initialize(bool keyOrb, GameManagerSimple manager)
    {
        isKeyOrb = keyOrb;
        gameManager = manager;
        
        if (isKeyOrb)
        {
            Debug.Log($"Key orb initialized: {gameObject.name}");
            // Optional: Make key orb slightly different visually
            // You could change the color or add a subtle glow here
        }
    }

    public void OnHit()
    {
        if (hasBeenHit) return;
        
        hasBeenHit = true;
        
        // Play hit sound
        if (audioSource != null && hitSound != null)
        {
            audioSource.Play();
        }
        
        // Show destroy effect
        if (destroyEffect != null)
        {
            GameObject effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
        }
        
        // Notify game manager
        if (gameManager != null)
        {
            if (isKeyOrb)
            {
                gameManager.OnKeyOrbHit();
            }
            else
            {
                gameManager.OnRegularOrbHit();
            }
        }
        
        // Destroy the orb
        Destroy(gameObject, 0.1f); // Small delay to allow sound to play
    }
}
