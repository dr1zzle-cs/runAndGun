using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{
    private bool collided;
    public int DamageAmount;
    public float radius;

    private void Start()
    {
        collided = false;
    }
    private void OnCollisionEnter(Collision co)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObject in colliders)
        {
            if (nearbyObject.tag == "Enemy")
            {
                PlayerManager.TakeDamage(DamageAmount);
            }
        }

         if (co.gameObject.tag != "Bullet" && co.gameObject.tag != "Player" && !collided)
        {
            
            Destroy(gameObject);
            collided = false;
        }

         else
        {
            Destroy(gameObject, 1f);
        }
    }
}
