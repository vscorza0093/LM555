using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
 
    public GameObject winGameMenu;
    public Text winGameText;
    public GameObject winGameButton;
    public Text freeCameraButtonText;
    public bool clickedButton = false;

    public static int resistorsInBoard = 0;
    public static int ledInBoard = 0;
    public static int capacitorInBoard = 0;
    public static int lm555InBoard = 0;

    public bool[] rightComponent = new bool[6];

    public static bool r1, r2, rLED, _LED, _Capacitor, _LM555;

    public static int r1Value, r2Value, rLEDValue;
    public static float capacitorValue;

    public GameObject[] resistorsObjs = new GameObject[3];
    private GameObject ledObj;
    public GameObject capacitorObj;
    private GameObject lm555Obj;

    public float ledClock;
    public Text clockText;

    private void Awake()
    {
        initialPosition = this.transform.position;
        initialRotation = this.transform.rotation;
        
        r1 = false;
        r2 = false;
        rLED = false;           
    }

    private void Update()
    {
 
        if (rLED != false)
        {
            resistorsObjs[2] = GameObject.FindGameObjectWithTag("RLED");
            if (resistorsObjs[2] == null)
            {
                rightComponent[3] = false;
                ledObj = GameObject.FindGameObjectWithTag("LED");
            }
        }
        if (_LED != false)
        {
            ledObj = GameObject.FindGameObjectWithTag("LED");
            if (ledObj == null)
            {
                rightComponent[2] = false;
                ledClock = 0;
                _LED = false;
                clockText.text = ledClock.ToString();
            }
        }
        if (_Capacitor != false)
        {
            capacitorObj = GameObject.FindGameObjectWithTag("Capacitor");
            if (capacitorObj == null)
            {
                _Capacitor = false;
                ledObj = GameObject.FindGameObjectWithTag("LED");
                if (ledObj != null)
                {
                    rightComponent[1] = false;
                    ledClock = 0;
                    ledObj.GetComponent<LEDBehavior>().DeactivateCoroutine();
                    clockText.text = ledClock.ToString();
                }
                else
                {
                    Debug.Log("no LED to deactivate");
                }       
            }
        }
        if (r1 != false)
        {
            resistorsObjs[0] = GameObject.FindGameObjectWithTag("R1");
            if (resistorsObjs[0] == null)
            {
                r1 = false;
                ledObj = GameObject.FindGameObjectWithTag("LED");
                if (ledObj != null)
                {
                    rightComponent[4] = false;
                    ledClock = 0;
                    ledObj.GetComponent<LEDBehavior>().DeactivateCoroutine();
                    clockText.text = ledClock.ToString();
                }
                else
                {
                    Debug.Log("no LED to deactivate");
                }
            }
        }
        if (r2 != false)
        {
            resistorsObjs[1] = GameObject.FindGameObjectWithTag("R2");
            if (resistorsObjs[1] == null)
            {
                rightComponent[5] = false;
                r2 = false;
                ledObj = GameObject.FindGameObjectWithTag("LED");
                if (ledObj != null)
                {
                    ledClock = 0;
                    ledObj.GetComponent<LEDBehavior>().DeactivateCoroutine();
                    clockText.text = ledClock.ToString();
                }
                else
                {
                    Debug.Log("no LED to deactivate");
                }
            }
        }
        if (_LM555 != false)
        {
            lm555Obj = GameObject.FindGameObjectWithTag("LM555");
            if (lm555Obj == null)
            {
                rightComponent[0] = false;
                _LM555 = false;
                ledObj = GameObject.FindGameObjectWithTag("LED");
                if (ledObj != null)
                {
                    ledClock = 0;
                    ledObj.GetComponent<LEDBehavior>().DeactivateCoroutine();
                    clockText.text = ledClock.ToString();
                }
                else
                {
                    Debug.Log("no LED to deactivate");
                }
            }
        }
        if (rightComponent[0] && rightComponent[1] && rightComponent[2] && rightComponent[3] && rightComponent[4] && rightComponent[5])
        {
            StartCoroutine(WinGameCoroutine());
        }
        else
        {
            Debug.Log("Not Win");
        }    
    }

    public void CloseWinMenu()
    {
        winGameMenu.SetActive(false);
    }

    IEnumerator WinGameCoroutine()
    {
        Debug.Log("Win");
        winGameMenu.SetActive(true);
        yield return new WaitForSeconds(2f);
        winGameText.enabled = false;
        winGameButton.SetActive(true);
    }

    public void FreeCameraControl()
    {
        this.GetComponent<CameraControl>().speed = 0.005f;
        this.GetComponent<CameraControl>().rotateSpeed = 0.5f;
        this.GetComponent<CameraControl>().verticalRotateSpeed = 0.5f;
        this.GetComponent<CameraControl>().rotateHorizontalValue = 0.5f;
        this.GetComponent<CameraControl>().rotateVerticalValue = 0.5f;
        if(!clickedButton)
        {
            freeCameraButtonText.text = "Camera Inicial";
            clickedButton = true;
        }
        else if (clickedButton)
        {
            freeCameraButtonText.text = "Camera Livre";
            clickedButton = false;
            this.GetComponent<CameraControl>().speed = 0f;
            this.GetComponent<CameraControl>().rotateSpeed = 0f;
            this.GetComponent<CameraControl>().verticalRotateSpeed = 0f;
            this.GetComponent<CameraControl>().rotateHorizontalValue = 0f;
            this.GetComponent<CameraControl>().rotateVerticalValue = 0f;
            this.transform.position = initialPosition;
            this.transform.rotation = initialRotation;
        }
    }
}
