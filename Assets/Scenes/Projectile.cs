using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    public float lifetime = 5f;
    public GameObject hitEffect;
    public AudioClip hitSound;

    private AudioSource audioSource;
    private Rigidbody rb;

    void Start()
    {
        // Get rigidbody
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }

        // Destroy projectile after lifetime
        Destroy(gameObject, lifetime);

        // Setup audio
        if (hitSound != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = hitSound;
            audioSource.playOnAwake = false;
        }

        Debug.Log($"Projectile created at {transform.position}");
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"COLLISION DETECTED! Hit: {collision.gameObject.name}");
        HandleHit(collision.gameObject, collision.contacts[0].point);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"TRIGGER DETECTED! Hit: {other.gameObject.name}");
        HandleHit(other.gameObject, transform.position);
    }

    void HandleHit(GameObject hitObject, Vector3 hitPoint)
    {
        // Play hit sound
        if (audioSource != null && hitSound != null)
        {
            audioSource.Play();
        }

        // Show hit effect
        if (hitEffect != null)
        {
            GameObject effect = Instantiate(hitEffect, hitPoint, Quaternion.identity);
            Destroy(effect, 2f);
        }

        // Check what we hit
        DestroyableTarget target = hitObject.GetComponent<DestroyableTarget>();
        if (target != null)
        {
            Debug.Log("HIT DESTROYABLE TARGET!");
            target.OnHit();
        }

        FloatingOrb orb = hitObject.GetComponent<FloatingOrb>();
        if (orb != null)
        {
            Debug.Log("HIT FLOATING ORB!");
            orb.OnHit();
        }

        // Destroy projectile
        Destroy(gameObject, 0.1f);
    }
    void Update()
{
    // Backup raycast collision check
    RaycastHit hit;
    if (Physics.Raycast(transform.position, rb.velocity.normalized, out hit, rb.velocity.magnitude * Time.fixedDeltaTime))
    {
        Debug.Log($"Raycast hit: {hit.collider.name}");
        HandleHit(hit.collider.gameObject, hit.point);
    }
}

}
