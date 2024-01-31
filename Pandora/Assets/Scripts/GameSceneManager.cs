using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameSceneManager : MonoBehaviour
{
   
    public static GameSceneManager Instance;
    public float uiLoadTime = 0.5f;
    private AsyncOperation asynOperation;
    

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        

    }


    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadNewScene(sceneName));
    }
    // 
    private IEnumerator LoadNewScene(string sceneName)
    {
        yield return null;
        //pauses anything run in update function
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(uiLoadTime);
        asynOperation = SceneManager.LoadSceneAsync(sceneName);
        while (!asynOperation.isDone)
        {
            yield return null; //wait single frame
        }
    }
}