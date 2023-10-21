using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagneticPull : MonoBehaviour
{
    Rigidbody triggeredRigidbody;
    GameObject triggeredObject;
    float directionY;
    float magneticPull = 1000f;
    bool inMagnetRange = false;
    bool touchingMagnet = false;
    void Update()
    {
        if (triggeredObject != null && inMagnetRange == true && touchingMagnet == false)
        {
            directionY = this.transform.position.y - triggeredObject.transform.position.y;
            //Attracts object
            if (directionY > 0.01 && touchingMagnet != true)
            {
                float velocity = directionY * magneticPull * Time.deltaTime;
                triggeredRigidbody.AddForce(0,velocity,0, ForceMode.Force);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Negative")
        {
            triggeredObject = other.gameObject;
            triggeredRigidbody = triggeredObject.GetComponent<Rigidbody>();
            inMagnetRange = true;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Connects Object
        triggeredRigidbody.useGravity = false;
        triggeredObject.transform.parent = this.gameObject.transform;
        touchingMagnet = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inMagnetRange = false;
        touchingMagnet = false;
        triggeredRigidbody.useGravity = true;
        StartCoroutine("DelayDetach");
    }
    public void switchedOff()
    {
        inMagnetRange = false;
        touchingMagnet = false;
        triggeredRigidbody.useGravity = true;
        this.transform.DetachChildren();
    }
    IEnumerator DelayDetach()
    {
        yield return new WaitForSeconds(1);
        this.transform.DetachChildren();
    }
}
