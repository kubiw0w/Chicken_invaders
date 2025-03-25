using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileImpact : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        if (collision.collider.tag == "Target")
        {
            Debug.Log("Hit target");
            Destroy(collision.gameObject);
            ScoreManagerScript.AddScore_level1();
        }
        else
        {
            Debug.Log("Something else: " + collision.collider.tag);
        }
    }
}
