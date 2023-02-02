using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LEDBehavior : MonoBehaviour
{
    private GameController gameController;

    [SerializeField]
    private GameObject[] lights;
    [SerializeField]
    private float startTime = 5f;

    private float timer;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();
        StartCoroutine(LEDClock(GameController.r1Value, GameController.r2Value, GameController.capacitorValue));
    }
    public void DeactivateCoroutine()
    {      
        lights[0].SetActive(false);
        lights[1].SetActive(false);
        StopAllCoroutines();
        
        Awake();
    }

    IEnumerator LEDClock(int r1, int r2, float c1Value)
    {
        if (GameController.capacitorValue > 0 && GameController.r1Value > 0 && GameController.r2Value > 0 && gameController.rightComponent[2] && gameController.rightComponent[0])
        {     
            float clock = 0.693f * (r1 + r2) * (c1Value);
            lights[0].SetActive(true);
            lights[1].SetActive(true);
            StartCoroutine(LEDTimer(clock));
            yield return new WaitForSeconds(clock);
            lights[0].SetActive(false);
            lights[1].SetActive(false);
            StartCoroutine(LEDTimer(clock));
            yield return new WaitForSeconds(clock);
            StartCoroutine(LEDClock(GameController.r1Value, GameController.r2Value, GameController.capacitorValue));
        }

        else
        {
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(LEDClock(GameController.r1Value, GameController.r2Value, GameController.capacitorValue));
        }
    }

    private IEnumerator LEDTimer(float clock)
    {
        float value;
        timer = clock;
        Debug.Log("timer " + timer);
        while (timer >= 0)
        {
            timer -= Time.deltaTime;
            value = timer / startTime;
            FormatTimerText();
            yield return null;
        }


        StopCoroutine(LEDTimer(clock));
        
    }

    public void FormatTimerText()
    {
        int hours = (int)(timer / 3600) % 24;
        int mins = (int)(timer / 60) % 60;
        float seconds = (int)(timer % 60);

        if(mins >= 0 && mins <= 9)
        {
            if(seconds >= 0 && seconds <= 9)
            {
                gameController.clockText.text = "0" + mins + ":" + "0" + seconds;
            }
            else
            {
                gameController.clockText.text = "0" + mins + ":" + seconds;
            }
        }

        else if (mins > 9 && seconds > 0 && seconds <= 9)
        {
            gameController.clockText.text = mins + ":" + "0" + seconds;
        }
        
        else
        {
            gameController.clockText.text = mins + ":" + seconds;
        }
        
    }

}
