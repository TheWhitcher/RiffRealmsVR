using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionsMenu;

    public void DeselectButton()
    {
        // Works but if the click is released outside the button it remains selected.
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void MoveToSkaldheim()
    {
        SceneManager.LoadScene("Skaldheim", LoadSceneMode.Single);
    }

    public void MoveToSakurajima()
    {
        SceneManager.LoadScene("Sakurajima", LoadSceneMode.Single);
    }

    public void OpenOptions()
    {
        mainMenu?.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void CloseOptions()
    {
        mainMenu?.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
