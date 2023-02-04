using UnityEngine;
[CreateAssetMenu(menuName = "ChoseVaraiant/OpenFightScene")]
public class ChooseVariantFight : ChooseVariant {
  [SerializeField]
  private ArmorItem _item;
  
  public override void Use() {
    Events.Inventory.AddItem(_item);
    Debug.Log("Here will be go to scene");
    Debug.Log("Можешь тут роботи перевірки на кубік щоб перевірити якесь своє значення ( наприклад скіп)" + Game.Dice.CurrentDiceCount);
    Events.Choose.CloseChooseWindow?.Invoke();
    Events.RollDiceEvent.WaitForRoll?.Invoke();
  }
}