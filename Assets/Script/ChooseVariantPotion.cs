using UnityEngine;


[CreateAssetMenu(menuName = "ChoseVaraiant/GetPotion")]
public class ChooseVariantPotion : ChooseVariant {
  [SerializeField]
  private PotionItem _potionItem;

  public override void Use() {
    Events.Inventory.AddItem?.Invoke(_potionItem);
    Debug.Log("You get potion");
    Events.Choose.CloseChooseWindow?.Invoke();
    Events.RollDiceEvent.WaitForRoll?.Invoke();
  }
}

//[CreateAssetMenu(menuName = "ChoseVaraiant/Poison")]
//public class ChooseVariantPoisonPotion : ChooseVariant {
//  [SerializeField]
//  private PoisonPotion _potionItem;
//
//  public override void Use() {
//    Events.Inventory.AddItem?.Invoke(_potionItem);
//    Debug.Log("You get potion");
//    Events.Choose.CloseChooseWindow?.Invoke();
//    Events.RollDiceEvent.WaitForRoll?.Invoke();
//  }
//}
//
//[CreateAssetMenu(menuName = "ChoseVaraiant/GetPotion")]
//public class ChooseVariantPotion : ChooseVariant {
//  [SerializeField]
//  private PowerPotionItem _potionItem;
//
//  public override void Use() {
//    Events.Inventory.AddItem?.Invoke(_potionItem);
//    Debug.Log("You get potion");
//    Events.Choose.CloseChooseWindow?.Invoke();
//    Events.RollDiceEvent.WaitForRoll?.Invoke();
//  }
//}