using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ComputerTarget : XRBaseInteractable
{
    [Header("Spawn")]
    public GameObject spherePrefab;
    public Transform spawnCenter;
    public int numberToSpawn = 20;
    public float spawnRadius = 2f;

    bool used = false;

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
        if (!used)
        {
            used = true;
            SpawnSpheres();
            // Optionally visually change computer
            var rend = GetComponentInChildren<Renderer>();
            if (rend) rend.material.SetColor("_EmissionColor", Color.green * 2f);
            // Disable interaction so it cannot be clicked again
            interactionLayerMask = 0;
        }
    }

    void SpawnSpheres()
    {
        if (!spherePrefab || !spawnCenter) return;
        for (int i = 0; i < numberToSpawn; i++)
        {
            Vector3 pos = spawnCenter.position + Random.insideUnitSphere * spawnRadius;
            pos.y = spawnCenter.position.y + Mathf.Abs(pos.y - spawnCenter.position.y) + 0.5f;
            GameObject s = Instantiate(spherePrefab, pos, Random.rotation);
            GameManager.Instance.RegisterSpawnedSphere(s);
        }
    }
}
