using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    /*
    public Text speedText;
    public Text rotateSpeedText;
    public Text verticalRotateSpeedText;

    [SerializeField]
    GameObject menuObj;
    */

    public float speed;
    public float rotateSpeed;
    public float verticalRotateSpeed;

    public float rotateHorizontalValue;
    public float rotateVerticalValue;

    /*

    private bool gamePaused = false;

    public bool menuOpened = false;

    */

    void Start()
    {
        /*
        speedText.text = speed.ToString("F2");

        rotateSpeedText.text = rotateSpeed.ToString("F2");

        verticalRotateSpeedText.text = verticalRotateSpeed.ToString("F2");
        */
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();

        CameraRotate();

        //if (Input.GetKeyDown(KeyCode.P) && !gamePaused)  PauseVideo();
        //else if (Input.GetKeyDown(KeyCode.P) && gamePaused) UnPauseVideo();

        ChangeCameraSpeed();

        //if (Input.GetKeyDown(KeyCode.R)) RestartScene();

        InterfaceMenu();

        if (Input.GetKey(KeyCode.N)) SceneManager.LoadScene("cenaBau");
        if (Input.GetKey(KeyCode.M)) SceneManager.LoadScene("cenaEspaco");
        if (Input.GetKey(KeyCode.L)) SceneManager.LoadScene("cenaEspaco2");
        if (Input.GetKey(KeyCode.K)) SceneManager.LoadScene("cenaEspacoBandeira");
        if (Input.GetKey(KeyCode.J)) SceneManager.LoadScene("cenaEspacoMapa");
        if (Input.GetKey(KeyCode.Q)) Application.Quit();
    }

    void InterfaceMenu()
    {
        /*
        if (Input.GetKeyDown(KeyCode.I) && !menuOpened)
        {
            menuOpened = true;
            menuObj.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.I) && menuOpened)
        {
            menuOpened = false;
            menuObj.SetActive(false);
        }
        */
    }

    void CameraMovement()
    {
        if (Input.GetKey(KeyCode.W)) transform.Translate(Vector3.forward * speed);

        if (Input.GetKey(KeyCode.S)) transform.Translate(Vector3.back * speed);

        if (Input.GetKey(KeyCode.A)) transform.Translate(Vector3.left * speed);

        if (Input.GetKey(KeyCode.D)) transform.Translate(Vector3.right * speed);
    }

    
    void CameraRotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) transform.Rotate(0f, rotateHorizontalValue * (rotateSpeed * -1) , 0f);

        if (Input.GetKey(KeyCode.RightArrow)) transform.Rotate(0f, rotateHorizontalValue * rotateSpeed, 0f);

        if (Input.GetKey(KeyCode.UpArrow)) transform.Rotate(rotateVerticalValue * (verticalRotateSpeed * -1), 0f, 0f);

        if (Input.GetKey(KeyCode.DownArrow)) transform.Rotate(rotateVerticalValue * verticalRotateSpeed, 0f, 0f);
    }
    

    /*
    void CameraRotate()
    {
        rotateHorizontalValue += rotateSpeed * Input.GetAxisRaw("Mouse X");

        rotateVerticalValue -= rotateSpeed * Input.GetAxisRaw("Mouse Y");

        transform.eulerAngles = new Vector3(rotateVerticalValue, rotateHorizontalValue, 0f);
    }
    */

    void ChangeCameraSpeed()
    {   
        /*
        //Camera Movement speed
        if (Input.GetKeyDown(KeyCode.C))
        {
            speed += 0.05f;
            speedText.text = speed.ToString("F2");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            speed -= 0.05f;
            speedText.text = speed.ToString("F2");
        }

        //Camera Rotate speed
        if (Input.GetKeyDown(KeyCode.F))
        {
            rotateSpeed += 0.1f;
            rotateSpeedText.text = rotateSpeed.ToString("F2");
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            rotateSpeed -= 0.1f;
            rotateSpeedText.text = rotateSpeed.ToString("F2");
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            verticalRotateSpeed += 0.1f;
            verticalRotateSpeedText.text = verticalRotateSpeed.ToString("F2");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            verticalRotateSpeed -= 0.1f;
            verticalRotateSpeedText.text = verticalRotateSpeed.ToString("F2");
        }
        */
    }   

    /*
    void PauseVideo()
    {
        gamePaused = true;
        Time.timeScale = 0;
    }

    void UnPauseVideo()
    {
        gamePaused = false;
        Time.timeScale = 1;
    }

    void RestartScene()
    {
        SceneManager.LoadScene("New Scene");
    }
    */

}
