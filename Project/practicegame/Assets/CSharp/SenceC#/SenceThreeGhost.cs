using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenceThreeGhost : MonoBehaviour
{
    //场景1里幽灵的移动（不可以被杀死，且可以穿过幽灵）
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

    private void Update()
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
            //Vector2 position = transform.position;
            //position.x += LookDirection * Speed * Time.deltaTime;
            //transform.position = position;
            rbody.velocity = new Vector2(Speed * LookDirection, rbody.velocity.y);

        }
        if (ChangeDirectionTimer <= 0)
        {
            ChangeDirectionTimer = ChangeDirectionTime;
            ChangeDirectionTimer -= Time.fixedDeltaTime;
            LookDirection *= -1;
            transform.localScale = new Vector3(LookDirection, 1, 1);
            //Vector2 position = transform.position;
            //position.x += LookDirection * Speed*Time.deltaTime;
            //transform.position = position;

            rbody.velocity = new Vector2(Speed * LookDirection, rbody.velocity.y);

        }
    }



    /// <summary>
    /// 碰撞伤害检测
    /// </summary>
    /// <param name="Player"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
        if (pc != null)
        {

            Debug.Log("碰到");
            pc.EmendationBlood(-10);



        }

    }
}
