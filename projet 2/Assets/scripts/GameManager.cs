using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public static class GameManager  {

    [SerializeField] static Scene[] levels;

    public static void Reset()
    {
            SceneManager.LoadScene("Level1");      
    }

}
