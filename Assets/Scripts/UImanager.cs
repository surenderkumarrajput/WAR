using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour {
    public GameObject panel;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
        }
    }
    public void resume()
    {
        FindObjectOfType<AudioManager>().Play("Tap");
        Time.timeScale = 1f;
        panel.SetActive(false);
    }
    public void MainMenu()
    {
        FindObjectOfType<AudioManager>().Play("Tap");
        Time.timeScale = 1f;
        SceneManager.LoadScene("FirstScreen");
    }
    public void Quit()
    {
        FindObjectOfType<AudioManager>().Play("Tap");
        Application.Quit();
    }
    public void End()
    {
        FindObjectOfType<AudioManager>().Play("Tap");
        Time.timeScale = 1f;
        SceneManager.LoadScene("FirstScreen");
    }
}
