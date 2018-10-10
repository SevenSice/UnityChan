using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{

    //要跳转的场景名
    public string sceneName = "";
    //要跳转的场景ID
    public int sceneID = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

     void GotoScene()
    {
        if (sceneName=="")
        {
            SceneManager.LoadScene(sceneID);
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }

    }
}
