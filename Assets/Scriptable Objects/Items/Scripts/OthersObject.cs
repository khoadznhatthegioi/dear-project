using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Others Object", menuName = "Inventory System/Items/Others")]
public class OthersObject : ItemObject
{
    public bool crayon;
    public void Awake()
    {
        type = ItemType.Others;
    }
}
