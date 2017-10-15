using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour{

    public static Shooting instance;

    public float speed = 20;
    public float coolDown = 3.0f;
    public int maxShot = 20;
    [HideInInspector]
    public int currShotCount;

    //bool gunReady = true;
    //float startTime = 0;

    void Awake(){
        if(instance == null){
            instance = this;
        }
    }

    void Start(){
        //startTime = Time.time;
        currShotCount = 0;
        GameManager.instance.maxShot = maxShot;
        //GameManager.instance.currShot = 0;
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            if(currShotCount < maxShot){
                AudioManager.PlayVariedEffect("GalagaShoot");

                GameObject bullet = Spawner.Spawn("Bullet");
                Rigidbody instantiatedProjectile = bullet.GetComponent<Rigidbody>();
                instantiatedProjectile.transform.position = transform.position;
                instantiatedProjectile.transform.rotation = transform.rotation;

                instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));   
            }  
        }
    }
}
