using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Code reference : https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadSceneAsync.html
public class LoadScene : MonoBehaviour {

    public string sceneName;
    public float minTime;
    void Start()
    {
        StartCoroutine(LoadSceneAsyncTask());
    }

    IEnumerator LoadSceneAsyncTask()
    {
        yield return new WaitForSeconds(minTime);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
