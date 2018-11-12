using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class Loading : MonoBehaviour {

    private AsyncOperation async;

    [SerializeField] private Image progressBar;
    [SerializeField] Text txtProgress;
    [SerializeField] bool WaitForUserInput = false;
    [SerializeField] float delay;
    [SerializeField] int sceneToLoad = -1;
    bool ready = false;


    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        Input.ResetInputAxes();
        System.GC.Collect();
        string name = GameObject.Find("LoadingManager").GetComponent<SceneLoader>().sceneToLoad;
        Debug.Log(name);
        if(sceneToLoad==-1)
        {
            async = SceneManager.LoadSceneAsync(name);
        }
        else
        {
            async = SceneManager.LoadSceneAsync(sceneToLoad);
        }
        async.allowSceneActivation = false;
        if(!WaitForUserInput)
        {
            Invoke("Activate", delay);
        }
    }
	
    public void Activate()
    {
        ready = true;
    }

	// Update is called once per frame
	void Update () {
		if(WaitForUserInput&&Input.anyKey)
        {
            if(async.progress>=0.89f&&SplashScreen.isFinished)
            {
                ready = true;
            }
        }

        if(progressBar)
        {
            progressBar.fillAmount = async.progress * 10 / 9;
        }

        if(txtProgress)
        {
            txtProgress.text = (async.progress * 1000 / 9).ToString("f2") + "%";
        }

        if(async.progress>=0.89f&&SplashScreen.isFinished&&ready)
        {
            async.allowSceneActivation = true;
        }
	}
}
