using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class InventoryRemoveActionItem : MonoBehaviour {
  [SerializeField]
  private List<RemoveInventoryButton> _usableItems;
  [SerializeField]
  private Button _close;
  [SerializeField]
  private CanvasGroup _canvasGroup;

  private Item _itemToChose;
  
  private void Awake() {    
    Events.Inventory.OpenRemoveItem += OpenInventoryWindow;
    _close.onClick.AddListener(CloseInventoryWindow);
    gameObject.SetActive(false);
  }

  private void OnDestroy() {
    Events.Inventory.OpenRemoveItem -= OpenInventoryWindow;

  }

  private void CloseInventoryWindow() {
    gameObject.SetActive(false);
  }

  public void OpenInventoryWindow (Item item) {
    foreach (var items in _usableItems) {
      items.Clear();
    }

    _itemToChose = item;
    
    for (int index = 0; index < Game.Player.Inventory.ActionItems.Count; index++) {
      ActionItem actionItem = Game.Player.Inventory.ActionItems[index];
      _usableItems[index].OnAction = OnAction;
      _usableItems[index].Init(actionItem);
    }

    _canvasGroup.alpha = 0;
    
    gameObject.SetActive(true);
    
    _canvasGroup.DOFade(1, 0.3f).SetEase(Ease.OutSine);;
  }

  private void OnAction (RemoveInventoryButton removeInventoryButton) {
    Events.Inventory.RemoveItem?.Invoke(removeInventoryButton.Item);
    Events.Inventory.AddItem?.Invoke(_itemToChose);
    CloseInventoryWindow();
  }

}