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
        equalTempColor = Color.white;
        cube1.GetComponent<Cube1>();
        cube2.GetComponent<Cube2>();
        calculatingEqualTemperature(cube1, cube2);
        Debug.Log((int)equalTemp);
    }
   
  
    // Update is called once per frame
    void Update()
    {
        
        if (cube1.temperature == (int)equalTemp )
        {
            
            cube1.material.material.color = equalTempColor;
        }
        if(cube2.temperature == (int)equalTemp)
        {
            cube2.material.material.color = equalTempColor;
        }
    }

  private float calculatingEqualTemperature(Cube1 temperature , Cube2 temperature2)
    {
       
        float Tm1 = temperature.mass * temperature.temperature;
        float Tm2 = temperature2.mass * temperature2.temperature;
        float masses = temperature.mass + temperature2.mass;

        equalTemp = (Tm1 + Tm2) / masses ;
        
        return (int)equalTemp;  
    }


  
    
}
