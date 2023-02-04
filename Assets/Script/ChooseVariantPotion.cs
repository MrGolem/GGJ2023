using UnityEngine;
[CreateAssetMenu(menuName = "ChoseVaraiant/GetPotion")]
public class ChooseVariantPotion : ChooseVariant {

  public override void Use() {
    Debug.Log("You get potion");
    Events.Choose.CloseChooseWindow?.Invoke();
  }
}