using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Slot_Buttons : MonoBehaviour
{
    private bool firstMenuIsActive = false;
    private bool secondMenuIsActive = false;

    [SerializeField]
    private GameObject[] menuObj;
    [SerializeField]
    private GameObject[] otherActiveMenu;
    [SerializeField]
    private GameObject[] otherActiveMenu2;


    public void OpenFirstMenu()
    {
        if (!firstMenuIsActive)
        {
            for (int i = 0; i < otherActiveMenu.Length; i++)
            {
                otherActiveMenu[i].GetComponent<GameObject>();
                if (otherActiveMenu[i].activeInHierarchy)
                {            
                    if (otherActiveMenu2[i].activeInHierarchy)
                    {
                        otherActiveMenu2[i].SetActive(false);
                        otherActiveMenu2[i].GetComponentInParent<Slot_Buttons>().secondMenuIsActive = false;
                    }
                    otherActiveMenu[i].SetActive(false);
                    otherActiveMenu[i].GetComponentInParent<Slot_Buttons>().firstMenuIsActive = false;
                }
            }
            menuObj[0].SetActive(true);
            firstMenuIsActive = true;
        }
    }
    public void OpenSecondMenu()
    {
        if (firstMenuIsActive && !secondMenuIsActive)
        {
            menuObj[1].SetActive(true);
            secondMenuIsActive = true;
        }
    }

    public void CloseMenu()
    {
        if (firstMenuIsActive)
        {
            if (secondMenuIsActive)
            {
                secondMenuIsActive = false;
                menuObj[1].SetActive(false);
            }
            firstMenuIsActive = false;
            menuObj[0].SetActive(false);
        }
    }
    public void CloseAllOpenedMenu()
    {
        for (int i = 0; i < otherActiveMenu.Length; i++)
        {
            otherActiveMenu[i].GetComponent<GameObject>();
            if (otherActiveMenu[i].activeInHierarchy)
            {
                if (otherActiveMenu2[i].activeInHierarchy)
                {
                    otherActiveMenu2[i].SetActive(false);
                    otherActiveMenu2[i].GetComponentInParent<Slot_Buttons>().secondMenuIsActive = false;
                }
                otherActiveMenu[i].SetActive(false);
                otherActiveMenu[i].GetComponentInParent<Slot_Buttons>().firstMenuIsActive = false;
            }
        }
    }
}
