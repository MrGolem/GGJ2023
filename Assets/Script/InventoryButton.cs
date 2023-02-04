using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour {
  [SerializeField]
  private Image _image;
  [SerializeField]
  private Button _button;

  public Item Item;

  private void Awake() {
    _button.onClick.AddListener(OnButtonClicked);
  }


  protected virtual void OnButtonClicked() {
    if(Item == null) return;
    Events.Inventory.OpenItemDescription?.Invoke(Item);
  }

  public void Clear() {
    _button.interactable = false;
    _image.gameObject.SetActive(false);
  }
  
  public void Init (Item item) {
    if(item == null) return;

    Item = item;
    Debug.Log(item.name);
    
    _button.interactable = true;
    _image.sprite = item.Image;
    _image.gameObject.SetActive(true);

  }
}