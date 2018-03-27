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
        mainMenu.SetActive(false);
        controlsMenu.SetActive(true);

    }

    public void PressQuit()
    {
        Application.Quit();
    }
}
