using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 18f;
    public float lifetime = 4f;
    public GameObject hitVFX;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision other)
    {
        var sb = other.gameObject.GetComponent<SphereBehavior>();
        if (sb != null)
        {
            sb.Pop();
        }
        if (hitVFX) Instantiate(hitVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
