using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ToScenes Object", menuName = "Inventory System/Items/ToScenes")]
public class ToScenesObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.ToScenes;
    }
}