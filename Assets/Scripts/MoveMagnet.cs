using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Content.Interaction;

public class MoveMagnet : MonoBehaviour
{
    public GameObject magnet;
    public XRLever lever;
    float speed = 1f;
    public bool isMoving;
   
    
    void Update()
    {
        if (isMoving)
        {
            magnet.transform.position = Vector3.Lerp(magnet.gameObject.transform.position, new Vector3(0, magnet.transform.position.y, 5), speed * Time.deltaTime);
        }
        else
        {
            magnet.transform.position = Vector3.Lerp(magnet.gameObject.transform.position, new Vector3(0, magnet.transform.position.y, 10), speed * Time.deltaTime);
        }
       

    }
    public void onLeverActivate()
    {
        isMoving = true;
    }
    public void onLeverDeactivate()
    {
        isMoving = false;
    }
    
    //public void shiftMagnet()
    //{
        //speed = 10.0f;
      //  rotationSpeed = 100.0f;

    //}
}
