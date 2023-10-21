using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Content.Interaction;

public class MoveMagnet : MonoBehaviour
{
    public Transform magnetTransform;
    public Vector2 JoystickValue;
    public XRJoystick joystick;
    float speed = 10.0f;
    void Update()
    {
        var magnetPosition = magnetTransform.localPosition;
        magnetPosition += new Vector3(JoystickValue.x * speed * Time.deltaTime, 0f, JoystickValue.y * speed * Time.deltaTime);
        
    }
    public void onJoystickValueChangeX(float x)
    {
        JoystickValue.x = x;
    }
    public void onJoystickValueChangeY(float y)
    {
        JoystickValue.y = y;
    }
    
    //public void shiftMagnet()
    //{
        //speed = 10.0f;
      //  rotationSpeed = 100.0f;

    //}
}
