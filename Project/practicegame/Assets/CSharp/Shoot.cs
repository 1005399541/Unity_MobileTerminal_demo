using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //子弹的类

    Rigidbody2D rbody;
    //Collider2D coll;


    //private void Start()
    //{
    //    rbody = GetComponent<Rigidbody2D>();
    //}
    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        //coll = GetComponent<Collider2D>();
        Destroy(this.gameObject,2f);
       
    }




    /// <summary>
    /// 子弹的发射的距离
    /// </summary>
    public void Fire(Vector2 LookDirection,float addforce)
    {
        rbody.AddForce(LookDirection*addforce);
        
     
    }






    /// <summary>
    /// 子弹的碰撞
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(this.gameObject);
            Debug.Log("发射到敌人身上并销毁");
        }
    }


        //}
        //private void OnCollisionExit2D(Collision2D collision)
        //{
        //    if (collision.gameObject.tag == "enemy")
        //    {
        //        Destroy(this.gameObject);
        //        Debug.Log("发射到敌人身上并销毁");
        //    }
        //}
    }
