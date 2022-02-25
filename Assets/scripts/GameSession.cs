using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int numOfBalls;
    [SerializeField] float restartSceneDelay;
    int enemyNums;
    private void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;

        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        enemyNums = FindObjectsOfType<Enemy>().Length;

        if (enemyNums == 0)
        {
            RestartinScene();
        }
    }


    public void RestartinScene()
    {
        StartCoroutine(waitAndRestart());
    }

    private IEnumerator waitAndRestart()
    {
        yield return new WaitForSeconds(restartSceneDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Destroy(gameObject);
    }
}
