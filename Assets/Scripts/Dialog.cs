using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour {
    public Text text;
    public string[] sentences;
    public float waittime;
     int index;
    public GameObject Continue;
    public string Scenename;
    private void Start()
    {
        StartCoroutine(type());
    }
    private void Update()
    {
        if(text.text == sentences[index])
        {
            Continue.SetActive(true);
        }
    }
    IEnumerator type()
    {
        foreach (char c in sentences[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(waittime);
        }
    }
    public void nextSentence()
    {
        Continue.SetActive(false);
        if (index<sentences.Length-1)
        {
            FindObjectOfType<AudioManager>().Play("Tap");
            index++;
            text.text = "";
            StartCoroutine(type());
        }
        else
        {
            text.text = "";
            SceneManager.LoadScene(Scenename);
        }
    }
}
