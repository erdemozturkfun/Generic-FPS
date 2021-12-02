using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GunObject gun; 
    public Camera camera;
    public ParticleSystem particleSystem;
    public Transform gunPoint;

    private float nextTimeToFire;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1.0f / gun.fireRate;
           Fire(); 
        }
    }

    void Fire()
    {
        particleSystem.Play();
        GetComponentInChildren<AudioSource>().Play();
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, gun.range))
        {
            if (hit.collider.GetComponent<Shootable>())
            {
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * gun.force);
                }
                hit.collider.GetComponent<Shootable>().Damage(gun.damage);
                
            }
        }
        
      
        
    }
    
    
}
