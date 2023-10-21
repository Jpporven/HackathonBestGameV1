using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube1 : MonoBehaviour
{

    public Renderer material;
    public float temperature;
    public float mass;
    public GameManager manager;
    public bool checkTemp;

// Start is called before the first frame update
void Start()
{
    checkTemp = false;
    mass = this.gameObject.GetComponent<Rigidbody>().mass;
    temperature = 75;
}

// Update is called once per frame
void Update()
{
    if (temperature == (int)manager.equalTemp && checkTemp == true)
    {
        Debug.Log("Temperature Found");
        StopAllCoroutines();
        checkTemp = false;
        return;
    }

}


private void OnCollisionEnter(Collision other)
{
    if (other.gameObject.name == "Cube2")
    {
        Debug.Log("Is Collinding");
        if (temperature > (int)manager.equalTemp)
        {
            checkTemp = true;
            StartCoroutine(DecreaseTemperature(checkTemp));
        }

        if (temperature < (int)manager.equalTemp)
        {
            checkTemp = true;
            StartCoroutine(IncreaseTemperature(checkTemp));

        }



    }
}

    IEnumerator IncreaseTemperature(bool temp)
    {
    while (temp == true)
    {
        yield return new WaitForSeconds(0.5f);

        Debug.Log(temperature);
        temperature++;
    }

}
    IEnumerator DecreaseTemperature(bool temp)
    {
    while (temp == true)
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log(temperature);
        temperature--;
    }
    
    }
}
