using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMagnet : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    void Update()
    {
        float translate = Input.GetAxis("Vertical") * speed;
        float rotate = Input.GetAxis("Horizontal") * rotationSpeed;
        

        translate *= Time.deltaTime;
        rotate *= Time.deltaTime;
        //
        transform.Translate(translate, 0, -rotate);

    }
}
