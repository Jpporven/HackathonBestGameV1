using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetSwitch : MonoBehaviour
{
    MagneticPull magneticPull; 
    void Start()
    {
        magneticPull = GetComponent<MagneticPull>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            switchOn();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            switchOff();
        }
    }
    void switchOn()
    {
        magneticPull.enabled = true;
    }
    void switchOff()
    {
        magneticPull.switchedOff();
        magneticPull.enabled = false;
    }
}
