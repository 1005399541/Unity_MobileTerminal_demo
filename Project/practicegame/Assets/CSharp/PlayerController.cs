using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //控制玩家的类

    public GameObject Player;
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;
    public GameObject c5;
    public GameObject c6;

    public float Speed;     //玩家的速度 


    public float Jumpforce; //跳跃力
    private int Jumpcount;  //跳跃次数
    private bool IsJump;   //是否启用跳跃
    private bool Isground; //是否在地面
    public Transform GroundCheck; //用于玩家的地面检测，是否与地面碰撞
    public LayerMask Ground;      //层级地面



    private int MaxPlayerblood;//玩家的最大血量
    private int CurrentPlayerblood;//玩家的实时血量
    private int CurrentHunger;//玩家的饥饿度
    private int MaxHunger;//玩家的最大饥饿度
    private float HungerTime;//饥饿间隔
    private float HungerTimer;//饥饿间隔计时器
    private bool IsHungerTime;//是否饥饿,真为触发扣血

    public static int  currentBlood;
    public static int maxBlood;

    public static AudioClip eatcilp;


    
    public AudioClip audiodeath;//死亡声音
    public AudioClip audioeat;//检道具的声音
    public AudioClip audiofire;//发射子弹的声音



    public GameObject shoot;//发射的子弹


    public Rigidbody2D rbody;      //获取刚体组件
    Animator anim;         //获得动画组件


    void Start()
    {
        DontDestroyOnLoad(Player);
        DontDestroyOnLoad(c1);
        DontDestroyOnLoad(c2);
        DontDestroyOnLoad(c3);
        DontDestroyOnLoad(c4);
        DontDestroyOnLoad(c5);
        DontDestroyOnLoad(c6);


        Jumpcount = 2;
        MaxPlayerblood = 100;


        CurrentPlayerblood = 80;
        MaxHunger = 100;
        CurrentHunger =80;
        HungerTime = 5f;
        HungerTimer = HungerTime;
        IsHungerTime = false;

        currentBlood = CurrentPlayerblood;
        maxBlood = MaxPlayerblood;
        eatcilp = audioeat;



        rbody = GetComponent<Rigidbody2D>();
        anim  = GetComponent<Animator>();
    }


    void Update()
    { if (currentBlood-CurrentPlayerblood==9)
        { CurrentPlayerblood = currentBlood; }
        if (currentBlood - CurrentPlayerblood != 9)
        { currentBlood = CurrentPlayerblood; }

        FireShoot();
        //Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name=="Sence"|| SceneManager.GetActiveScene().name == "GameOverSence" || SceneManager.GetActiveScene().name == "StartSence")
        {
            Destroy(Player);
            Destroy(c1);
            Destroy(c2);
            Destroy(c3);
            DontDestroyOnLoad(c4);
            DontDestroyOnLoad(c5);
            DontDestroyOnLoad(c6);

        }

       

        if (Input.GetButtonDown("Jump"))
        {
            IsJump = true;
            //Debug.Log("启用跳跃");
        }


        UIManager.Instance.BloodImage(CurrentPlayerblood, MaxPlayerblood);
        UIManager.Instance.BlueImage(CurrentHunger, MaxHunger);


    }
    private void FixedUpdate()
    {

        //UIManager.Instance.BloodImage(CurrentPlayerblood,MaxPlayerblood);
        //UIManager.Instance.BlueImage(CurrentHunger,MaxHunger);


        Isground = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, Ground);

        //Debug.Log(rbody.velocity.y);
        MoveHorizontal();
        MoveJump();
        MoveJumpAnim();
        ContiuneLossHunger();
        
        
    }




    /// <summary>
    /// 控制玩家的左右移动
    /// </summary>
    private void MoveHorizontal()
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        if (MoveX != 0) { transform.localScale=new Vector3 (MoveX,1,1);/*Debug.Log("转向");*/ }
        rbody.velocity = new Vector2(MoveX * Speed, rbody.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(rbody.velocity.x));   //控制左右移动的动画
        
    }



    /// <summary>
    /// 控制玩家的跳跃
    /// </summary>
    private void MoveJump()
    {
        if (Isground)
        {
            Jumpcount = 2;
        }
        if (Isground&&IsJump&&Jumpcount>0)
        {   
                rbody.velocity = new Vector2(rbody.velocity.x, Jumpforce);
                Jumpcount--;
                //Debug.Log("地面跳跃");
                IsJump = false;
                //anim.SetBool("Jump",true);
            

        }
        if ( !Isground && IsJump&& Jumpcount > 0)
        {    
                rbody.velocity = new Vector2(rbody.velocity.x, Jumpforce);
                Jumpcount--;
                //Debug.Log("空中跳跃");
                IsJump = false;
            anim.SetBool("Jumpdown", false);
                //anim.SetBool("Jump", true);

        }
        //if (Input.GetButtonDown("Jump"))
        //{
        //    rbody.velocity = new Vector2(rbody.velocity.x, Jumpforce);
        //}
    }


    /// <summary>
    /// 发射子弹
    /// </summary>
    public void FireShoot()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

           GameObject bullts =Instantiate(shoot,rbody.position, Quaternion.identity);

            Shoot shoots = bullts.GetComponent<Shoot>();
            if (shoots!=null)
            { Vector2 LookDirection = new Vector2(transform.localScale.x, 0);

                shoots.Fire(LookDirection,20000);
                MusicManager.instance.PlayMusic(audiofire);
                //Destroy(bullts,2f);
                Debug.Log("发射子弹");
            }
         

        }
       
    }


    /// <summary>
    /// 跳跃动画切换
    /// </summary>
    private void MoveJumpAnim()
    {
        if (Isground)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Jumpdown", false);
        }
        if (rbody.velocity.y > 0&&!Isground)
        {
            anim.SetBool("Jump", true);return;
        }
        if (rbody.velocity.y <0&&!Isground)
        {
            anim.SetBool("Jump", true);
            anim.SetBool("Jumpdown", true);
            return;
        }
   
    }




    /// <summary>
    /// 玩家持续损失饥饿度，若为零则死亡
    /// </summary>
    private void ContiuneLossHunger()
    {
        
        if (!IsHungerTime&&HungerTimer>0)
        {
            HungerTimer -= Time.fixedDeltaTime;
            if (HungerTimer < 0) { IsHungerTime = true; HungerTimer = HungerTime; }
        }
       
       
        //Debug.Log("饥饿度比·"+CurrentHunger + "/"+ MaxHunger);
        if (CurrentHunger > 0&&IsHungerTime)
        {
            CurrentHunger = CurrentHunger -1;
            IsHungerTime = false;
        }
        if(CurrentHunger<=0)
        {
            MusicManager.instance.PlayMusic(audiodeath);
            Invoke("death",1f);
        }
       
    }

    /// <summary>
    /// 补充或损失饥饿度 
    /// </summary>
    public void EmendationHunger(int addHunger)
    {
       
        if (CurrentHunger > 0 && CurrentHunger < MaxHunger)
        {

            if ((CurrentHunger + addHunger) < 0)
            {
                MusicManager.instance.PlayMusic(audiodeath);
                Invoke("death", 1f);return;
            }
            if ((CurrentHunger + addHunger) > MaxHunger)
            {
                CurrentHunger = MaxHunger;return;
            }
            CurrentHunger += addHunger;

        }
        if (CurrentHunger >= MaxHunger)
        {
            CurrentHunger = MaxHunger;
        }
    }


    /// <summary>
    /// 补充或损失血量
    /// </summary>
    public  void EmendationBlood(int addBleed)
    {
        //if (CurrentPlayerblood <= 0) { Invoke("death", 1f); return; }
        //if (addBleed >= 0)
        //{
        //    if ((CurrentPlayerblood + addBleed) >= MaxPlayerblood)
        //    {
        //        CurrentPlayerblood = MaxPlayerblood;
        //    }
        //    if (CurrentPlayerblood + addBleed < MaxPlayerblood)
        //    {
        //        CurrentPlayerblood += addBleed;
        //    }
        // return;
        //}
        //if (addBleed < 0)
        //{
        //    if (CurrentPlayerblood + addBleed <= 0)
        //    {
        //        Invoke("death", 1f); return;
        //    }
        //    CurrentPlayerblood -= addBleed;
        //}
        if (CurrentPlayerblood <= 0) { MusicManager.instance.PlayMusic(audiodeath); Invoke("death", 1f); return;  }
        if (CurrentPlayerblood > 0 && CurrentPlayerblood < MaxPlayerblood)
        {

            if ((CurrentPlayerblood + addBleed) < 0)
            {
                MusicManager.instance.PlayMusic(audiodeath);
                Invoke("death", 1f); return;
            }
            if ((CurrentPlayerblood + addBleed) > MaxPlayerblood)
            {
                CurrentPlayerblood = MaxPlayerblood; return;
            }
            CurrentPlayerblood += addBleed;

        }
        if (CurrentPlayerblood >= MaxPlayerblood)
        {
            CurrentPlayerblood = MaxPlayerblood;
        }
        Debug.Log("血量比"+CurrentPlayerblood+"/"+MaxPlayerblood);
    }



    public static void addprop(int add)
    {
           currentBlood+= add;
        MusicManager.instance.PlayMusic(eatcilp);
        //Debug.Log("血量比" + currentBlood + "/" + maxBlood);
    }


    /// <summary>
    /// 玩家死亡
    /// </summary>
    private void death()
    {
        SceneManager.LoadScene("GameOverSence");
        

    }

  
    
}
