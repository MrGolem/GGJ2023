using UnityEngine;

public class FightInventoryButton : InventoryButton {
    [SerializeField]
    private AudioSource audioSourceForSpell;

    protected override void OnButtonClicked() {
    if (Item is ActionItem actionItem) {
      audioSourceForSpell.Play();
      actionItem.Use();
      Clear();
    }
  }
}