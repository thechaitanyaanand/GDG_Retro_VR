using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class GameManagerSimple : MonoBehaviour
{
    [Header("CRT Monitor Settings")]
    public ParticleSystem monitorSmokeParticleSystem;
    
    [Header("Orb Settings")]
    public GameObject orbPrefab;
    public Transform player;
    public int numberOfOrbs = 15;
    public float spawnRadius = 5f;
    public float orbSpawnHeight = 1.5f;
    
    [Header("Win Condition Objects")]
    public GameObject secretKey;
    public TextMeshPro foundText;
    
    [Header("Game Settings")]
    public bool gameEnded = false;
    
    private List<GameObject> spawnedOrbs = new List<GameObject>();
    private int keyOrbIndex;
    private bool crtMonitorDestroyed = false;

    void Start()
    {
        // Ensure win condition objects are disabled at start
        if (secretKey != null)
            secretKey.SetActive(false);
            
        if (foundText != null)
            foundText.gameObject.SetActive(false);
    }

    public void OnCRTMonitorDestroyed()
    {
        if (crtMonitorDestroyed || gameEnded) return;
        
        crtMonitorDestroyed = true;
        
        // Enable smoke particle system
        if (monitorSmokeParticleSystem != null)
        {
            monitorSmokeParticleSystem.gameObject.SetActive(true);
            monitorSmokeParticleSystem.Play();
        }
        
        // Spawn orbs
        SpawnOrbs();
        
        Debug.Log("CRT Monitor destroyed! Orbs spawning...");
    }

    void SpawnOrbs()
    {
        if (player == null || orbPrefab == null) return;
        
        // Clear any existing orbs
        ClearOrbs();
        
        // Randomly select which orb will be the key orb
        keyOrbIndex = Random.Range(0, numberOfOrbs);
        
        for (int i = 0; i < numberOfOrbs; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            GameObject newOrb = Instantiate(orbPrefab, spawnPosition, Random.rotation);
            
            // Name the orb
            newOrb.name = "orb";
            
            // Setup the orb component
            FloatingOrb orbComponent = newOrb.GetComponent<FloatingOrb>();
            if (orbComponent == null)
            {
                orbComponent = newOrb.AddComponent<FloatingOrb>();
            }
            
            // Set if this is the key orb
            orbComponent.Initialize(i == keyOrbIndex, this);
            
            spawnedOrbs.Add(newOrb);
        }
        
        Debug.Log($"Spawned {numberOfOrbs} orbs. Key orb is at index {keyOrbIndex}");
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = player.position + new Vector3(randomCircle.x, orbSpawnHeight, randomCircle.y);
        
        // Make sure the orb spawns above ground
        RaycastHit hit;
        if (Physics.Raycast(spawnPosition + Vector3.up * 10f, Vector3.down, out hit, 20f))
        {
            spawnPosition.y = hit.point.y + orbSpawnHeight;
        }
        
        return spawnPosition;
    }

    public void OnKeyOrbHit()
    {
        if (gameEnded) return;
        
        gameEnded = true;
        
        // Enable secret key
        if (secretKey != null)
        {
            secretKey.SetActive(true);
        }
        
        // Enable found text
        if (foundText != null)
        {
            foundText.gameObject.SetActive(true);
        }
        
        // Clear remaining orbs
        ClearOrbs();
        
        Debug.Log("Game Ended - Key Orb Found!");
        
        EndGame();
    }

    public void OnRegularOrbHit()
    {
        Debug.Log("Regular orb hit and destroyed");
    }

    void ClearOrbs()
    {
        foreach (GameObject orb in spawnedOrbs)
        {
            if (orb != null)
            {
                Destroy(orb);
            }
        }
        spawnedOrbs.Clear();
    }

    void EndGame()
    {
        // Add any end game logic here
        Debug.Log("Victory! Game completed!");
    }
}
