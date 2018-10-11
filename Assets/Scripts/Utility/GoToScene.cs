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


     void GotoScene()
    {
        if (sceneName=="")
        {
            Game.screenUI().FadeAndGo(sceneID);          
        }
        else
        {
            Game.screenUI().FadeAndGo(sceneName);
        }

    }
}
