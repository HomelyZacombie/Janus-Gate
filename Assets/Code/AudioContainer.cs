using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioContainer : MonoBehaviour
{
    [SerializeField] AudioSource GameAmbiant;
    [SerializeField] AudioSource MainMenuAmbiant;
    private void Start()
    {
       // GameAmbiant.Pause();
       // MainMenuAmbiant.Play();
    }
    public void PlayGameAmbiant()
    {
        GameAmbiant.Play();
        Debug.Log("Main Game music load");

    }
    public void PauseGameAmbiant()
    {
        GameAmbiant.Pause();
    }
    public void PlayMainMenuAmbiant()
    {
        MainMenuAmbiant.Play();
        Debug.Log("Main menu music play");
    }
    public void PauseMainMenuAmbiant()
    {
        MainMenuAmbiant.Pause();
    }
}
