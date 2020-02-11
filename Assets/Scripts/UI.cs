using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {
    public GameObject firstoption, menu,quit;
    private void Start()
    {
        firstoption.SetActive(true);
        menu.SetActive(false);
        quit.SetActive(false);

    }
   
    public void Play()
    {
        FindObjectOfType<AudioManager>().Play("Tap");
        SceneManager.LoadScene("Intro");
    }
    public void quitMethod()
    {
        FindObjectOfType<AudioManager>().Play("Tap");
        Application.Quit();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            firstoption.SetActive(false);
            menu.SetActive(true);
            quit.SetActive(true);
        }
    }
}
