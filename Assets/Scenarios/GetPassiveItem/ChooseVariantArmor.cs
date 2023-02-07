using UnityEngine;

[CreateAssetMenu(menuName = "ChoseVaraiant/GetArmor")]
public class ChooseVariantArmor : ChooseVariant
{
    [SerializeField]
    private ArmorItem _armorItem;
    public override void Use()
    {
        Events.Inventory.AddItem?.Invoke(_armorItem);
        Debug.Log("You get armor");
        Events.Choose.CloseChooseWindow?.Invoke();
        Events.RollDiceEvent.WaitForRoll?.Invoke();
    }
}
