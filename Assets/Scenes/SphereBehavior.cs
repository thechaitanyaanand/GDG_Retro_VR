using UnityEngine;

public class SphereBehavior : MonoBehaviour
{
    public float floatAmplitude = 0.25f;
    public float floatSpeed = 1.5f;
    public int id = -1; // optional
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position = startPos + Vector3.up * Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.Rotate(Vector3.up, 45f * Time.deltaTime);
    }

    public void Pop()
    {
        // small VFX or sound can be played here
        GameManager.Instance.SpherePopped(this.gameObject);
        Destroy(gameObject);
    }
}
