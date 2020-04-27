using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RefreshScene : MonoBehaviour {

	public void Refresh(int scene)
    {
        if(scene == 1)
        {
            SceneManager.LoadScene(1);
        }

        if(scene == 3)
        {
            SceneManager.LoadScene(3);
        }
    }
}
