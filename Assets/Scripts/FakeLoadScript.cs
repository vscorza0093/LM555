using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FakeLoadScript : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(FakeLoad());
    }

    IEnumerator FakeLoad()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
