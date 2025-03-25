using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pistol : MonoBehaviour
{
    public InputActionProperty input;
    public GameObject projectilePrefab;  
    public Transform shootPoint;        
    public float shootForce = 500f;     
    private bool isHeld = false; 

    void Update()
    {
        if (isHeld && input.action.WasPressedThisFrame()) 
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(shootPoint.forward * shootForce);
        }
        Destroy(projectile, 5f);
    }

    public void SetHeldState(bool held)
    {
        isHeld = held;
    }
}
