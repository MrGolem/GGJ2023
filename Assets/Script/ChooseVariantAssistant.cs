using UnityEngine;
[CreateAssetMenu(menuName = "ChoseVaraiant/Assistent")]
public class ChooseVariantAssistant : ChooseVariant {
  [SerializeField]
  private AssistentItem _assistent;
    
  public override void Use() {
    Events.Inventory.AddItem(_assistent);
    
    Events.Choose.CloseChooseWindow?.Invoke();
    Events.RollDiceEvent.WaitForRoll?.Invoke();
  }
}