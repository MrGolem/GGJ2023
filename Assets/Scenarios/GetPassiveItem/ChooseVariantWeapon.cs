using UnityEngine;
[CreateAssetMenu(menuName = "ChoseVaraiant/GetSword")]
public class ChooseVariantWeapon : ChooseVariant
{
    [SerializeField]
    private WeaponItem _weaponItem;

    public override void Use()
    {
        Events.Inventory.AddItem?.Invoke(_weaponItem);
        Debug.Log("You get weapon");
        Events.Choose.CloseChooseWindow?.Invoke();
        Events.RollDiceEvent.WaitForRoll?.Invoke();
    }
}
