using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelSelect;

    public void LoadLevel(int levelNum)
    {
        SceneManager.LoadScene(levelNum);
    }

    public void ShowLevelSelect()
    {
        levelSelect.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);  
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
