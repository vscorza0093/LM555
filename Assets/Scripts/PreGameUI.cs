using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreGameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject[] text;
    [SerializeField]
    private Text buttonText;
    public void Text2()
    {
        text[0].SetActive(false);
        text[1].SetActive(true);
    }

    public void Text3()
    {
        text[1].SetActive(false);
        text[2].SetActive(true);
    }

    public void Text4()
    {
        text[2].SetActive(false);
        text[3].SetActive(true);
    }

    public void Close()
    {
        text[3].SetActive(false);
        SceneManager.LoadScene(1);
    }
}
