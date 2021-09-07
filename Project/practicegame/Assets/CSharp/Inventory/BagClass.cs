using System.Collections;
using System.Collections.Generic;
using UnityEngine;





[CreateAssetMenu(fileName = "new Inventory", menuName = "Inventory/new Bag")]
public class BagClass :ScriptableObject
{

    /// <summary>
    /// 制作背包的菜单
    /// </summary>
    public List<Item> ItemList=new List<Item>();
}
