using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Usable/Potion/Poison")]
public class PoisonPotion : ActionItem
{
    [SerializeField]
    private int PoisonDamage;

    public override void Use()
    {
        Debug.Log("I poison enemy");
    }
}
