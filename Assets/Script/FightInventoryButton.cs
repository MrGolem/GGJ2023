public class FightInventoryButton : InventoryButton {
  protected override void OnButtonClicked() {
    if (Item is ActionItem actionItem) {
      actionItem.Use();
      Clear();
    }
  }
}