using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public Camera cam;
    public int MaximumRange;
    public GameObject projectile;
    public Transform firePoint;
    public float projectileSpeed;
    public float fireRate;

    private Vector3 destination;
    private float timeToFire;

    Animator anim;
    bool isFiring;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            isFiring = true;
            ShootProjectile();
            anim.SetTrigger("Firing");
        }
    }

    void ShootProjectile()
    {

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }

        else
            destination = ray.GetPoint(MaximumRange);

        InstantiateProjectile(firePoint);
    }

    void InstantiateProjectile(Transform firepoint)
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
    }
}
