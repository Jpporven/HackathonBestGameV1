using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseGlide : MonoBehaviour
{
    public float airResistance = 0.01f;
    Rigidbody rigidbod;

    // Start is called before the first frame update
    void Start()
    {
        rigidbod = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.E))
       {
            rigidbod.drag = rigidbod.drag + airResistance;
       }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(rigidbod.drag > 0)
            {
                rigidbod.drag = rigidbod.drag - airResistance;
            }
        }
    }
}
