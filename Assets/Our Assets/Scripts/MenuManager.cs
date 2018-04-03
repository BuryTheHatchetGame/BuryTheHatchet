using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string sceneToLoad;

    public GameObject mainMenu;
    public GameObject controlsMenu;

    public void Start()
    {
        mainMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }

    public void PressPlay()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void PressControls()
    {
        controlsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void ReturnToMain()
    {
        mainMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }

    public void PressQuit()
    {
        Application.Quit();
    }
}
