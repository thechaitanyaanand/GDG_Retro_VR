using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private List<GameObject> activeSpheres = new List<GameObject>();
    public GameObject keyPrefab;
    public Transform keySpawnPoint;
    public int totalSpheresToPop = 20;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void RegisterSpawnedSphere(GameObject s)
    {
        activeSpheres.Add(s);
    }

    public void SpherePopped(GameObject s)
    {
        if (activeSpheres.Contains(s)) activeSpheres.Remove(s);
        CheckAllPopped();
    }

    void CheckAllPopped()
    {
        int popped = totalSpheresToPop - activeSpheres.Count;
        // If all popped
        if (activeSpheres.Count == 0 && popped >= totalSpheresToPop)
        {
            GiveKey();
        }
    }

    void GiveKey()
    {
        if (keyPrefab && keySpawnPoint)
        {
            Instantiate(keyPrefab, keySpawnPoint.position, keySpawnPoint.rotation);
            // Optionally play a sound or UI
            Debug.Log("Key spawned! Player can pick it up.");
        }
    }
}
