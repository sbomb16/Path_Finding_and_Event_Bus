using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Scenes : MonoBehaviour {

    public int sceneNum;
    //public bool hasQueue = true;

    public void changeScenes(int scene)
    {

        switch (scene)
        {
            case 0:
                SceneManager.LoadScene(0);
                return;

            case 1:
                SceneManager.LoadScene(1);
                return;

            case 2:
                SceneManager.LoadScene(2);
                return;

            case 3:
                SceneManager.LoadScene(3);
                //if (hasQueue && SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(5))
                //{
                //    Command_Log.doQueue = true;
                //}
                return;

            case 4:
                Application.Quit();
                return;

            case 5:
                SceneManager.LoadScene(4);
                return;

            case 6:
                SceneManager.LoadScene(5);
                return;

            default:
                SceneManager.LoadScene(0);
                return;
        }        
    }
}
