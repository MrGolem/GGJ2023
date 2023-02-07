using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour {
  [SerializeField]
  private List<InventoryButton> _usableItems;
  [SerializeField]
  private InventoryButton _weaponItem;
  [SerializeField]
  private InventoryButton _armorItem;
  [SerializeField]
  private InventoryButton assistantItem;
  [SerializeField]
  private Button _close;
  [SerializeField]
  private CanvasGroup _canvasGroup;
  
  private void Awake() {    
    Events.Inventory.OpenInventory += OpenInventoryWindow;
    _close.onClick.AddListener(CloseInventoryWindow);
    gameObject.SetActive(false);
  }

  private void OnDestroy() {
    Events.Inventory.OpenInventory -= OpenInventoryWindow;

  }

  private void CloseInventoryWindow() {
    gameObject.SetActive(false);
  }

  public void OpenInventoryWindow () {
    foreach (var items in _usableItems) {
      items.Clear();
    }

    for (int index = 0; index < Game.Player.Inventory.ActionItems.Count; index++) {
      ActionItem actionItem = Game.Player.Inventory.ActionItems[index];
      _usableItems[index].Init(actionItem);
    }
    
    _weaponItem.Init(Game.Player.Inventory.WeaponItem);
    _armorItem.Init(Game.Player.Inventory.ArmorItem);
    assistantItem.Init(Game.Player.Inventory.AssistentItem); 
    
    _canvasGroup.alpha = 0;
    
    gameObject.SetActive(true);
    
    _canvasGroup.DOFade(1, 0.3f).SetEase(Ease.OutSine);;
  }

}