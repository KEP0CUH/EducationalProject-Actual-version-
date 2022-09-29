using System;
using UnityEngine;

[CreateAssetMenu(fileName="newCollectableItem",menuName= "ScriptableObjects/Items/newCollectableItem", order=51)]
public class CollectableItemData : ItemData
{
    [Range(1, int.MaxValue / 2)][SerializeField]
    private int maxCount = 40;              

    public int MaxCount => maxCount;
}

