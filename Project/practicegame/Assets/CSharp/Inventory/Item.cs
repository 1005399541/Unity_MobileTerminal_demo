using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="new Item",menuName ="Inventory/new Item")]

public class Item :ScriptableObject
{
    /// <summary>
    /// 制作可以放入背包的道具
    /// </summary>


    public Sprite Itemimage;//物品的图片
    public string Itemname;//物品的名字
    public int Itemnumber;//物品的数量
    [TextArea]
    public string Itemintroduce;//物品的简介
    public bool equipment;//是否是装备，true则是 
}
