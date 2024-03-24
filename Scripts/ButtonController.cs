using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public AudioSource musicbutton;
    public bool musicflag = true;

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

     public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

        public void MusicButton()
    {

        if (musicflag == true)
        {
            musicbutton.Pause();
            musicflag = false;
        }
        else
        {
            musicbutton.Play();
            musicflag = true;
        }
    }
}
