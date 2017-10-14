using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour{
    public Rigidbody projectile;
    public float speed = 20;

   

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody instantProjectile = Instantiate(projectile,
                                                           transform.position,
                                                           transform.rotation)
                as Rigidbody;

            instantProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));

            Destroy(instantProjectile.gameObject, .5f);
        }

        

    }
}
