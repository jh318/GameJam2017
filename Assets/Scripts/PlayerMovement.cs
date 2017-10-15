using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0F;
    public int health =3;
    public float clampOffSet = 10.0f;

    public GameManager lives;

    public CameraShake cam;
    

    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        screenPos.x = Mathf.Clamp(screenPos.x, 0f, Screen.width);

        transform.position = Camera.main.ScreenToWorldPoint(screenPos);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemies") {
            Debug.Log("Collide");
            //health-=1;
            GameManager.instance.MinusLives(1);
            collider.gameObject.SetActive(false);

            cam.Shake();
        }
    }
}

