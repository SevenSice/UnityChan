using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public float speed = 200f; //角色移动速度
    public float jumpHeight = 5f; //角色跳的高度

     protected Rigidbody2D rigidBody2D;
    protected Animator animator;

    private bool UpKey;//用来判断按键是否按下
    protected bool isGround = false;

    protected AnimatorStateInfo animatorState;

    void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    public void Update()
    {
        Control();
        StateMachine();
    }
    public virtual void Control()
    {
        UpKey = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow); //判断按键是否按下

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) //向左
        {
            Move(-1);
            Direction(-1);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) //向右
        {
            Move(1);
            Direction(0);
        }
        if (UpKey == false)//如果松开按键，角色停止，修复角色会滑动的效果
        {
            Move(0);
        }
        if (Input.GetKeyDown(KeyCode.Space)) //跳
        {
            if (isGround == false) { return; }
            Jump();
        }

    }

    public virtual void Move(int i)//走动
    {
        rigidBody2D.velocity = new Vector2(i * speed * Time.deltaTime, rigidBody2D.velocity.y);
        animator.SetFloat("Move", Mathf.Abs(i));
    }

    public virtual void Direction(int i)//转向
    {
        transform.eulerAngles = new Vector3(0, 180 * i, 0);
    }

    void Jump()
    {
        rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpHeight);
        Debug.Log("jump");
        animator.SetTrigger("Jump");
    }

    //动画状态机
    void StateMachine()
    {
        animator.SetBool("Ground", isGround);
        animator.SetFloat("Velocity_Y", rigidBody2D.velocity.y);

        //animatorState得到当前动画状态，0代表animator里面Layer的index序号。
        animatorState = animator.GetCurrentAnimatorStateInfo(0);
    }

    //碰撞
    void OnCollisionStay2D(Collision2D collision2D)
    {
        isGround = true;
    }
    void OnCollisionExit2D(Collision2D collision2D)
    {
        isGround = false;
    }
}
