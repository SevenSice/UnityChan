/* https://msdn.microsoft.com/zh-cn/library/dscyy5s0(v=vs.80).aspx 微软迭代器用法解释 */
/* https://docs.unity3d.com/ScriptReference/WaitForSeconds.html */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenUI : MonoBehaviour
{


    public Image ui_blackImage;  //黑色渐变图片
    private float Speed = 0.12f ; //渐变速度


    void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {
        FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        ui_blackImage.color = new Vector4(
            ui_blackImage.color.r, 
            ui_blackImage.color.g, 
            ui_blackImage.color.b, 
            Mathf.Clamp01(ui_blackImage.color.a + Speed) /* 把速度限制在0到1之间 */
            );
    }

    void FadeIn()
    {
        ui_blackImage.color = new Vector4(
            ui_blackImage.color.r,
            ui_blackImage.color.g,
            ui_blackImage.color.b,
            1  /* ui_blackImage.color=1 */
            );
        Speed = -Mathf.Abs(Speed);
    }

    void FadeOut()
    {
        ui_blackImage.color = new Vector4(
            ui_blackImage.color.r,
            ui_blackImage.color.g,
            ui_blackImage.color.b,
            0  /* ui_blackImage.color=0 */
            );
        Speed = Mathf.Abs(Speed);
    }

    //淡出
    public void FadeAndGo(string map)
    {
        StartCoroutine(Go(map));
    }

    public void FadeAndGo(int map)
    {
        StartCoroutine(Go(map));
    }

    IEnumerator Go(string map)
    {
        FadeOut();
        yield return new WaitForSeconds(0.7f);//迭代器
        SceneManager.LoadScene(map);
    }

    IEnumerator Go(int map)
    {
        FadeOut();
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(map);
    }
}
