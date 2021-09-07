using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManger : MonoBehaviour
{
    //背包管理的单例


    public Text SoltIn;  //实际背包中的物品描述
    public GameObject use;//物品的使用按钮
    public BagClass MyBag;//背包
    public GameObject SoltAlltransform;//背包格子的总坐标
    public GameObject EmptySolt;//空的背包单元格
    public List<GameObject> solts = new List<GameObject>();//这个列表用于储存道具的那个表单



    public static InventoryManger instance { get; private set; }

    public void Awake()
    {
        if (instance != null) { Destroy(instance);}
        instance = this;
    }

    public void OnEnable()

    {

        InventoryManger.instance.RefreshBag();
        SoltIn.text=" ";
     
    }


    /// <summary>
    /// 点击显示简介
    /// </summary>
    public void feahClick(string  soltinto)
    {
        
        InventoryManger.instance.SoltIn.text =soltinto;
      
}




/// <summary>
/// 背包物品的显示
/// </summary>
public void RefreshBag()
    {
        //删除格子的节点
        
        for(int i = 0; i < SoltAlltransform.transform.childCount; i++)
        {
            if (SoltAlltransform.transform.childCount == 0) { break; }
            Destroy(SoltAlltransform.transform.GetChild(i).gameObject);
            solts.Clear();
            Debug.Log("节点删除成功");
        }



        //创建格子的节点

        for (int i = 0; i < MyBag.ItemList.Count; i++)
        {
            solts.Add(Instantiate(EmptySolt));
            solts[i].transform.SetParent(SoltAlltransform.transform);
            solts[i].GetComponent<Solt>().SetSolt(MyBag.ItemList[i]);
            solts[i].GetComponent<Solt>().SoltID = i;

            Debug.Log("节点创建成功");
        }

    }
}
