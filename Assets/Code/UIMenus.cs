using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenus : MonoBehaviour
{

    [SerializeField] string MainMenuScene = "Main Menu";
    [SerializeField] string MainGameScene= "Main Game Scene";
    //[SerializeField] private string EndGameScene= "End Screen";
    //[SerializeField] private string LeaveGame = "Exit Game";
    [SerializeField] GameObject PauseMenu;
   
    void Start()
    {
        //for menu audio
    }
    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Is Pauseing");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Continue()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("Time resumed");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void LoadMainMenuScene(string MainMenu)
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void LoadMainGameScene(string MainGameScene)
    {
        //string name calls 'name' of the scene you want
        SceneManager.LoadScene("MainGameScene");
    }
}
