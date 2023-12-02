using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] Animator loadingScreen;

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

    public void MoveToHome()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void MoveToUnknown()
    {
        SceneManager.LoadScene("Unknown", LoadSceneMode.Single);
    }
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    public void ChangeToSkaldheim()
    {
        loadingScreen.SetBool("ChangeToSkaldheim", true);
    }

    public void ChangeToHome()
    {
        loadingScreen.SetBool("ChangeToHome", true);
    }

    public void ChangeToSakurajima()
    {
        loadingScreen.SetBool("ChangeToSakurajima", true);
    }

    public void ChangeToUnknown()
    {
        loadingScreen.SetBool("ChangeToUnknown", true);
    }

    public void ChangeToRestart()
    {
        loadingScreen.SetBool("ChangeToRestart", true);
    }
}
