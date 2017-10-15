using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0F;
    public int health =3;
    public float clampOffSet = 10.0f;

    public GameManager lives;

    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        screenPos.x = Mathf.Clamp(screenPos.x, 0f + clampOffSet, Screen.width - clampOffSet);

        transform.position = Camera.main.ScreenToWorldPoint(screenPos);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemies") {
            health-=1;
            lives.MinusLives(1);
        }
    }
}

