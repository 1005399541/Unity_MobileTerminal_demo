using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Solt : MonoBehaviour
{

    //背包里的单元格道具的预设
    public Item ItemSolt;
    public Image Soltimage;//物品的图片 
    public Text SoltNumber;//物品的数量
    public string Soltintroduce;//物品的简介
    public string SoltName;//物品的名字
    public GameObject SoltIntroduce;// 用于物品格子的显示于关闭
    public int SoltID;//每个格子的ID

    public GameObject uesbutton;//使用的按钮
    private bool isName;//是否出现名字
    public GameObject EmptySolt;//空的背包单元格
    public BagClass MyBag;
    public Item Heart;




    private void OnEnable()
    {
        isName = false;
        uesbutton.SetActive(isName);
    }

    /// <summary>
    /// 点击显示相应物品的介绍
    /// </summary>
    public void refeshClick()
    {
        InventoryManger.instance.feahClick(Soltintroduce);
        isName = !isName;
        uesbutton.SetActive(isName);
        Debug.Log(SoltName);
    }



    /// <summary>
    /// 通过点击，比对名字使用物品
    /// </summary>
    public void useprop()
    {
        //if (SoltName == "MiddlingBlood" || SoltName == "HighBlood" || SoltName == "SmallBlood"||SoltName=="HeartHeart")
        //{
        //    //PlayerController pc = new PlayerController();
        //    //pc.EmendationBlood((int)10) ;
        //    PlayerController.addprop(9);
        //}

        
        if (SoltNumber.text == "1")
        {
           
            for (int i = 0; i < MyBag.ItemList.Count; i++)
            {
              
                if (MyBag.ItemList[i] != null)
                {
                    
                    if (MyBag.ItemList[i].Itemname == "Heart")
                    {
                        PlayerController.addprop(9);
                        Destroy(this.gameObject);
                        MyBag.ItemList[i] =null;
                       
                        Debug.Log("使用成功,并清除物品");
                    }

                }
            }
        }




        if (SoltNumber.text != "1")
        {

            for (int i = 0; i < MyBag.ItemList.Count; i++)
            {

                if (MyBag.ItemList[i] != null)
                {

                    if (MyBag.ItemList[i].Itemname == "Heart")
                    {
                        { PlayerController.addprop(9);  }
                        Heart.Itemnumber--;
                        SoltNumber.text = Heart.Itemnumber.ToString();
                        Debug.Log("使用成功，物品减一");
                        
                    }

                }
            }
        }
    }




    /// <summary>
    /// 道具同步
    /// </summary>
    /// <param name="item"></param>
    public void SetSolt(Item item)
    {
        if (item ==null)
        {
           SoltIntroduce.SetActive(false);
            return;
        }
        Soltimage.sprite = item.Itemimage;
        SoltNumber.text = item.Itemnumber.ToString();
        Soltintroduce = item.Itemintroduce;
        SoltName= item.Itemname;/*Debug.Log(SoltName);*/
    }




}
