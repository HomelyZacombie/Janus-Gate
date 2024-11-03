using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenus : MonoBehaviour
{

    [SerializeField] private string MainMenuScene = "Main Menu";
    public string MainGameScene= "Main Game Scene";
    //[SerializeField] private string EndGameScene= "End Screen";
    //[SerializeField] private string LeaveGame = "Exit Game";
   
    void Start()
    {
        //for menu audio
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
