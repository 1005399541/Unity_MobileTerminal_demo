using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{


    public Image Bloodimage;//红条
    public Image Blueimage;//蓝条
    public GameObject bag;
    private bool Ispause;//是否暂停,真为停
    private bool IsBag;//是否打开背包,真为开
    //UI相关的单例模式

    public static UIManager Instance { get; private set; }

    public void Start()
    {
        Instance = this;
        Ispause = true;
        IsBag =false;
        bag.SetActive(IsBag);
    }


    /// <summary>
    /// 游戏的暂停与开始
    /// </summary>
    public void Pause()
    {
        Ispause = !Ispause;
        if (Ispause)
        { Time.timeScale = 0; }
        if(!Ispause)
        { Time.timeScale = 1; }
       
    }
    


    /// <summary>
    /// 背包的打开与关闭
    /// </summary>
    public void UseBag()
    {

        InventoryManger.instance.RefreshBag();
        IsBag = !IsBag;
        if (IsBag)
        {
            bag.SetActive(IsBag);
        }
        if (!IsBag)
        {
            bag.SetActive(IsBag);
        }
       
    }


  
    /// <summary>
    /// 蓝条的显示
    /// </summary>
    /// <param name="CurrentPlayerblood"></param>
    /// <param name="MaxPlayerblood"></param>
    public void BloodImage(int CurrentPlayerblood, int MaxPlayerblood)
    {
        Bloodimage.fillAmount = (float)CurrentPlayerblood / MaxPlayerblood;
    }






    /// <summary>
    /// /红条的显示
    /// </summary>
    /// <param name="CurrentHunger"></param>
    /// <param name="MaxHunger"></param>
    public void BlueImage(int CurrentHunger, int MaxHunger)
    {
        Blueimage.fillAmount = (float)CurrentHunger / MaxHunger;

    }




}
