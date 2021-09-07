using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenceTwoenemyDragon : MonoBehaviour
{
    //场景2里龙的移动（只可以被踩死，且不会穿过龙）
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



    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
        if (pc != null)
        {
            if (pc.rbody.velocity.y < 0)
            {
                Destroy(this.gameObject);
                return;
            }
            pc.EmendationBlood(-10);
        }

    }


}
