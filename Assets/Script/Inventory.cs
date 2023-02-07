using System.Collections.Generic;
using UnityEngine;
public class Inventory {
  public Inventory() {
    Events.Inventory.AddItem += AddItem;
    Events.Inventory.RemoveItem += RemoveItem;
  }

   ~Inventory() {
     Events.Inventory.AddItem -= AddItem;
     Events.Inventory.RemoveItem -= RemoveItem;
  }

  private void AddItem (Item item) {
    Events.Fight.UpdateStatsUI?.Invoke();
    
    if (item is ActionItem actionItem) {
      if (ActionItems.Count < 3) {
        Debug.Log("BBB" + actionItem);
        ActionItems.Add(actionItem);
      } else {
        Debug.Log("cccc" + actionItem);
        Events.Inventory.OpenRemoveItem?.Invoke(actionItem);
      }
      return;
    }

    if (item is WeaponItem weaponItem) {
      WeaponItem = weaponItem;
      return;
    }
    
    if (item is ArmorItem armorItem) {
      ArmorItem = armorItem;
      return;

    }

    if (item is AssistentItem assistentItem) {
      Game.FightData._assistantCharacter = new Character(assistentItem.StatsConfig);
      AssistentItem = assistentItem;
      return;
    }
  }

  private void RemoveItem (Item item) {
    Events.Fight.UpdateStatsUI?.Invoke();

    if (item is ActionItem actionItem) {
      ActionItems.Remove(actionItem);
      return;
    }

    if (item is WeaponItem weaponItem) {
      WeaponItem = null;
      return;
    }
    
    if (item is ArmorItem armorItem) {
      ArmorItem = null;
      return;

    }

    if (AssistentItem is AssistentItem assistentItem) {
      AssistentItem = null;
      return;
    }
  }


  public List<ActionItem> ActionItems = new List<ActionItem>();

  public WeaponItem WeaponItem ;
  public ArmorItem ArmorItem;
  public AssistentItem AssistentItem;
}