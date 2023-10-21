using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Cube1 cube1;
    public Cube2 cube2;
    private Color equalTempColor;
    public float equalTemp;

    // Start is called before the first frame update
    void Start()
    {
        cube2.GetComponent<Renderer>();
        cube1.GetComponent<Renderer>();
        cube1.GetComponent<Cube1>();
        cube2.GetComponent<Cube2>();
        equalTempColor = Color.magenta;
        calculatingEqualTemperature(cube1, cube2);
        Debug.Log((int)equalTemp);
    }
   
  
    // Update is called once per frame
    void Update()
    {
        
        if (cube1.temperature == (int)equalTemp )
        {

            //cube1.Transition();
           
        }
        if(cube2.temperature == (int)equalTemp)
        {
            cube2.material.material.color = equalTempColor;
        }
    }

  public float calculatingEqualTemperature(Cube1 cube1, Cube2 cube2)
    {
       
        float Tm1 = cube1.mass * cube1.temperature;
        float Tm2 = cube2.mass * cube2.temperature;
        float masses = cube1.mass + cube2.mass;
            
        equalTemp = (Tm1 + Tm2) / masses ;

        Debug.Log("" + cube1.mass + " " + cube2.mass + " " + cube1.temperature + " " + cube2.temperature);
        return (int)equalTemp;

        
    }


  
    
}
