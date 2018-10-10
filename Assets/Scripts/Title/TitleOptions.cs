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

    // Use this for initialization
    void Start()
    {
        id = 0;
        UpdateHandPosition();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            id--;
            if (id < 0) id = Buttons.Length - 1;
            UpdateHandPosition();
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            id++;
            id = id % Buttons.Length;
            UpdateHandPosition();
        }
    }

    //更新手指位置
    void UpdateHandPosition()
    {
        hand.position = new Vector3(Buttons[id].position.x + xOffset[id], Buttons[id].position.y - 0.2f, hand.position.z);
    }
}
