using System;

public class RemoveInventoryButton : InventoryButton {
  public Action<RemoveInventoryButton> OnAction;
  
  protected override void OnButtonClicked() {
    OnAction?.Invoke(this);
  }
}