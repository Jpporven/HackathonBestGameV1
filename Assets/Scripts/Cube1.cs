using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cube1 : MonoBehaviour
{
    public float time;
    public Renderer material;
    public Material Material;
    public float targetpoint;
    public Color color;
    public float temperature;
    public float mass;
    public GameManager manager;
    public bool checkTemp;
    public TMP_Text temperatureText;
    public int currentColorIndex = 0;
    public int temperatureColorIndex = 1;


    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        Material.color = Color.red;
        checkTemp = false;
        mass = this.gameObject.GetComponent<Rigidbody>().mass;
        temperature = 75;
        temperatureText.text = "Temperature = " + temperature;
    }

    // Update is called once per frame
    void Update()
    {
        temperatureText.text = "Temperature = " + temperature;
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
                Transition();
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
        time = Time.time;
        while (temp == true)
        {
            yield return new WaitForSeconds(0.1f);

            Debug.Log(temperature);
            temperature++;
        }
        targetpoint = Time.time - time;

    }
    IEnumerator DecreaseTemperature(bool temp)
    {
        
        while (temp == true)
        {
            yield return new WaitForSeconds(0.3f);

            Debug.Log(temperature);
            temperature--;
            targetpoint = Time.time - time;
        }
        Debug.Log(targetpoint);
        
    }

    public void Transition()
    {
        Debug.Log(targetpoint);
        Material.color = Color.Lerp(Material.color, Color.magenta, targetpoint);

    }


}