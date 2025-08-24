using UnityEngine;

public class CarController : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    public float stopDistance = 0.1f;
    public bool loop = true;
    public int highlightWaypointIndex = 2; // index where computers exist

    private int currentIndex = 0;

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        Transform target = waypoints[currentIndex];
        Vector3 dir = (target.position - transform.position);
        if (dir.sqrMagnitude > stopDistance * stopDistance)
        {
            transform.position += dir.normalized * speed * Time.deltaTime;
            Quaternion look = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, look, Time.deltaTime * 5f);
        }
        else
        {
            currentIndex++;
            if (currentIndex >= waypoints.Length)
            {
                if (loop) currentIndex = 0;
                else currentIndex = waypoints.Length - 1;
            }
        }
    }

    public int GetCurrentWaypointIndex() { return currentIndex; }
}
