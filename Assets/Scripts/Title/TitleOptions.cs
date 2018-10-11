using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleOptions : MonoBehaviour
{

    public Transform hand;
    private int id = 0;
    //界面的几个按钮
    public Transform[] Buttons;
    //按钮坐标向量
    Vector3 vector3;
    //手指上下移动时X轴的偏移量
    public float[] xOffset;
    //生成一个World对象对游戏整体属性进行调节
    private World world;
    //按钮选择的声音
    public AudioClip chooseSound;
    //确定的声音
    public AudioClip confirmSound;


    // Use this for initialization
    void Start()
    {
        id = 0;
        UpdateHandPosition();

        world = FindObjectOfType<World>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))//向上
        {
            id--;
            if (id < 0) id = Buttons.Length - 1;

            world.sound.PlaySE(chooseSound);//播放选择音效
            UpdateHandPosition();
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//向下
        {
            id++;
            id = id % Buttons.Length;

            world.sound.PlaySE(chooseSound);//播放选择音效
            UpdateHandPosition();
        }

        //确定
        if(Input.GetKeyDown(KeyCode.Z)|| Input.GetKeyDown(KeyCode.KeypadEnter)|| Input.GetKeyDown(KeyCode.Space))
        {
            switch(id)
            {
                //new game
                case 0: Game.screenUI().FadeAndGo("Level1");
                    break;
                //load game
                case 1:
                    break;
                //Exit
                case 2: Application.Quit();
                    break;
            }
            world.sound.PlaySE(confirmSound);
        }
    }

    //更新手指位置
    void UpdateHandPosition()
    {
        hand.position = new Vector3(Buttons[id].position.x + xOffset[id], Buttons[id].position.y - 0.2f, hand.position.z);
    }
}
