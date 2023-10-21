using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceScaling : MonoBehaviour
{
    public Transform XrController;
    public float playerDistanceFromText;
    public float distanceThreshold;
    public float scaleSpeed;

    // Update is called once per frame
    void Update()
    {
        playerDistanceFromText = Vector3.Distance(XrController.position, transform.position);

        if(playerDistanceFromText <= distanceThreshold)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1.2f, 1.2f, 1.2f), scaleSpeed);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0f, 0f, 0f), scaleSpeed);
        }
    }
}
