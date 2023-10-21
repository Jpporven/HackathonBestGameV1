using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string startingScene;

    public GameObject fadeScreen;
    public GameObject mainmenuScreen;
    public GameObject settingsScreen;
    public GameObject creditsScreen;
    public GameObject controlsScreen;

    public void Start()
    {
        Settings();
    }

    public void StartGame()
    {
        StartCoroutine(StartingGame());        
    }

    public void Settings()
    {
        StartCoroutine(LoadMenu(settingsScreen, creditsScreen, mainmenuScreen, controlsScreen));
    }

    public void Credits()
    {
        StartCoroutine(LoadMenu(creditsScreen, settingsScreen, mainmenuScreen, controlsScreen));
    }

    public void Controls()
    {
        StartCoroutine(LoadMenu(controlsScreen, settingsScreen, mainmenuScreen, creditsScreen));
    }

    public void BackButton()
    {
        StartCoroutine(LoadMenu(mainmenuScreen, creditsScreen, settingsScreen, controlsScreen));
    }

    IEnumerator LoadMenu(GameObject a, GameObject b, GameObject c, GameObject d)
    {
        //play animation
        a.GetComponent<Animator>().SetBool("fade", true);

        yield return new WaitForSeconds(1f);

        b.GetComponent<Animator>().SetBool("fade", false);
        c.GetComponent<Animator>().SetBool("fade", false);
        d.GetComponent<Animator>().SetBool("fade", false);

        a.SetActive(true);

        b.SetActive(false);
        c.SetActive(false);
        d.SetActive(false);
    }

    IEnumerator StartingGame()
    {
        fadeScreen.SetActive(true);

        yield return new WaitForSeconds(4);

        SceneManager.LoadScene(startingScene);
    }
}
