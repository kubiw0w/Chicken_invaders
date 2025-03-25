using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Carabine : MonoBehaviour
{
    public Transform shootPoint;
    public LineRenderer lineRenderer;
    public InputActionProperty input;
    public LayerMask hitLayerMask; 
    public float rayDistance = 100f; 
    //public GameObject hitEffectPrefab; 

    private bool isPrimaryHeld = false; 
    private bool isSecondaryHeld = false; 

    void Update()
    {
        ShootLaserContinuous();
        if (isPrimaryHeld && isSecondaryHeld && input.action.WasPressedThisFrame())
        {
            ShootLaserWithImpact();
        }
    }

    private void ShootLaserContinuous()
    {
        Ray ray = new Ray(shootPoint.position, shootPoint.forward);
        RaycastHit hit;

        lineRenderer.SetPosition(0, shootPoint.position);

        if (Physics.Raycast(ray, out hit, rayDistance, hitLayerMask))
        {
            lineRenderer.SetPosition(1, hit.point);
            //Debug.Log("Shoot into: " + hit.collider);  
        }
        else
        {
            lineRenderer.SetPosition(1, ray.origin + ray.direction * rayDistance);
        }
    }

    private void ShootLaserWithImpact()
    {
        Ray ray = new Ray(shootPoint.position, shootPoint.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, hitLayerMask))
        {
            if (hit.collider.tag == "Target")
            {
                ScoreManagerScript.AddScore_level2();
                Destroy(hit.collider.gameObject);
            }
        }
        
    }

    public void SetPrimaryHeldState(bool state)
    {
        isPrimaryHeld = state;
    }

    public void SetSecondaryHeldState(bool state)
    {
        isSecondaryHeld = state;
    }
}
