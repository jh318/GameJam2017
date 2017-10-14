using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour{

<<<<<<< HEAD
   
=======
    public float speed = 20;
>>>>>>> 86f4e43d821e08731cee4c547059ededd658ed11

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
<<<<<<< HEAD
            Rigidbody instantProjectile = Instantiate(projectile,
                                                           transform.position,
                                                           transform.rotation)
                as Rigidbody;

            instantProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));

            Destroy(instantProjectile.gameObject, .5f);
=======
            GameObject bullet = Spawner.Spawn("Bullet");
            Rigidbody instantiatedProjectile = bullet.GetComponent<Rigidbody>();
            instantiatedProjectile.transform.position = transform.position;
            instantiatedProjectile.transform.rotation = transform.rotation;

            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
>>>>>>> 86f4e43d821e08731cee4c547059ededd658ed11
        }

        

    }
}
