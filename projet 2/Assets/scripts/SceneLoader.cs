using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private AsyncOperation async;
    public string sceneToLoad;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Load Next Scene
    /// </summary>
    public void LoadScene()
    {
        if (async == null)
        {
            Scene current = SceneManager.GetActiveScene();
            async = SceneManager.LoadSceneAsync(current.buildIndex + 1);
            async.allowSceneActivation = true;
        }
    }

    public void LoadScene(int index)
    {
        if (async == null)
        {
            async = SceneManager.LoadSceneAsync(index);
            async.allowSceneActivation = true;
        }
    }

    public void LoadScene(string name)
    {
        if (async == null)
        {
            async = SceneManager.LoadSceneAsync(name);
            async.allowSceneActivation = true;
        }
    }

    public void LoadingScene(string sceneToLoad)
    {
        this.sceneToLoad = sceneToLoad;
        SceneManager.LoadScene("Loading");
    }

    public void LoadingScene()
    {
        int toLoad = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(toLoad);
    }
}
