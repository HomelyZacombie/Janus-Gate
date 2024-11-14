using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenus : MonoBehaviour
{

    [SerializeField] string MainMenuScene = "MainMenu";
    [SerializeField] string MainGameScene= "Main Game Scene";
    //[SerializeField] private string EndGameScene= "End Screen";
    [SerializeField] string LeaveGame = "Exit Game";
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject EndGame;
    [SerializeField] float EndTime = 3f;
    [SerializeField] GameObject WonGame;
    private bool EndTrue = false;
    private bool WonTrue = false;

    void Start()
    {
        //for menu audio
        //PauseMenu = GameObject.Find("PauseMenu");
        //EndGame = GameObject.Find("EndGame");
        EndGame.SetActive(false);
        WonGame.SetActive(false);
    }
    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Continue()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Won()
    {
        WonGame.SetActive(true);
        WonTrue = true;
    }

    public void End()
    {
        
        EndGame.SetActive(true);
        EndTrue = true;
        
    }

    private void Update()
    {
        if (WonTrue == true)
        {
            EndTime -= Time.deltaTime;
            if (EndTime <= 0)
            {
                SceneManager.LoadScene("MainMenu");
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        if (EndTrue == true)
        {
            EndTime -= Time.deltaTime;
            if (EndTime <= 0)
            {
                SceneManager.LoadScene("MainMenu");
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
    public void LoadMainMenuScene(string MainMenu)
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadMainGameScene(string MainGameScene)
    {
        //string name calls 'name' of the scene you want
        SceneManager.LoadScene("MainGameScene");
    }
   
    public void LoadLeaveGame(string ExitGame)
    {
        Application.Quit();

    }
}
