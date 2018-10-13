using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : Controller
{

    public override void Control()
    {
        base.Control();
        if (Input.GetKeyDown(KeyCode.J))
        {
            rigidBody2D.velocity = new Vector2(0, rigidBody2D.velocity.y);
            animator.SetInteger("Attack", animator.GetInteger("Attack") + 1);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            rigidBody2D.velocity = new Vector2(0, rigidBody2D.velocity.y);
            animator.SetTrigger("Skill");
        }
    }
    public override void Move(int i)
    {
        if(CanNotMove()==false)
        {
            rigidBody2D.velocity = new Vector2(i * speed * Time.deltaTime, rigidBody2D.velocity.y);
        }
        animator.SetFloat("Move", Mathf.Abs(i));
    }
    public override void Direction(int i)
    {
        if(CanNotMove()==true)
        {
            return;
        }
        transform.eulerAngles = new Vector3(0, 180 * i, 0);
    }
    bool CanNotMove()
    {
        return animatorState.IsTag("lock");//返回标签Tag是否为lock的返回值值
    }
}
