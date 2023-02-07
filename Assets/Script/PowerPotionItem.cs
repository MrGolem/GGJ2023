using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Usable/Potion/Power")]
public class PowerPotionItem : ActionItem
{
    [SerializeField]
    private int powerX;

    public override void Use()
    {
        Debug.Log("I doubled your power");
    }
}