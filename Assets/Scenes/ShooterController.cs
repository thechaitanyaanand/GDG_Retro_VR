using UnityEngine;
using UnityEngine.InputSystem; // if using new input system
using UnityEngine.XR.Interaction.Toolkit;

public class ShooterController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform muzzle;
    public InputActionProperty shootAction; // action-based input (XR Interaction)
    public float cooldown = 0.15f;
    float cd = 0f;

    void Update()
    {
        cd -= Time.deltaTime;
        bool fired = false;

        // If using Action-based XR input, read action
        if (shootAction.action != null)
        {
            fired = shootAction.action.ReadValue<float>() > 0.1f;
        }

        if (fired && cd <= 0f)
        {
            Fire();
            cd = cooldown;
        }
    }

    void Fire()
    {
        if (!projectilePrefab || !muzzle) return;
        var go = Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);
    }
}
