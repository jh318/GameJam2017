﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0F;
    public int health = 50;
    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemies") {
            health--;
        }
    }
}
