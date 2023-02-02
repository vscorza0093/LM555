using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject diagramImage;

    public GameObject[] slotsOcupados;

    private bool firstMenuIsOpen = false;

    [SerializeField]
    private GameObject firstMenuObj;
    public void OpenFirstMenu()
    {
        if (!firstMenuIsOpen)
        {
            Time.timeScale = 0;
            firstMenuIsOpen = true;
            firstMenuObj.SetActive(true);
        }
    }
    public void CloseFirstMenu()
    {
        if (firstMenuIsOpen)
        {
            Time.timeScale = 1;
            firstMenuIsOpen = false;
            firstMenuObj.SetActive(false);
        }
    }
    public void OpenDiagram()
    {
        diagramImage.SetActive(true);
    }
    public void CloseDiagram()
    {
        CloseFirstMenu();
        diagramImage.SetActive(false);
    }
    public void ResetScene()
    {
        for (int i = 0; i < slotsOcupados.Length; i++)
        {
            if(slotsOcupados[i].GetComponent<AddComponents_Script>().slotPlaceHolderObj != null)
            {
                slotsOcupados[i].GetComponent<AddComponents_Script>().RemoveComponent();
            }
        }
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
