using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenceThreePumpkin : MonoBehaviour
{
    //场景3里南瓜怪的移动（只可以被杀死，且可以穿过）


    public float Speed; //水平移动速度
    private float LookDirection;//飞行的方向
    public bool StartDirection;//初始飞行方向,若为真则向右
    public float ChangeDirectionTime;//多久改变方向
    private float ChangeDirectionTimer;//改变方向计时器


    Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        LookDirection = StartDirection ? 1 : -1;
        ChangeDirectionTimer = ChangeDirectionTime;
    }


    void Update()
    {

    }


    private void FixedUpdate()
    {
        EnemyMoveX();
    }




    /// <summary>
    /// 敌人的水平移动
    /// </summary>
    public void EnemyMoveX()
    {
        if (ChangeDirectionTimer > 0)
        {
            ChangeDirectionTimer -= Time.fixedDeltaTime;
            transform.localScale = new Vector3(LookDirection, 1, 1);
            rbody.velocity = new Vector2(Speed * LookDirection, rbody.velocity.y);

        }
        if (ChangeDirectionTimer <= 0)
        {
            ChangeDirectionTimer = ChangeDirectionTime;
            ChangeDirectionTimer -= Time.fixedDeltaTime;
            LookDirection *= -1;
            transform.localScale = new Vector3(LookDirection, 1, 1);
            rbody.velocity = new Vector2(Speed * LookDirection, rbody.velocity.y);

        }
    }





    /// <summary>
    /// 碰撞伤害检测
    /// </summary>
    /// <param name="Player"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //与玩家的检测
        PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
        if (pc != null)
        {

            Debug.Log("碰到");
            pc.EmendationBlood(-20);



        }

        //与子弹的检测
        Shoot shoots = collision.gameObject.GetComponent<Shoot>();
        if (shoots != null)
        {
            Destroy(this.gameObject);
        }

    }
}
