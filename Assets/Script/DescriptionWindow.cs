using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DescriptionWindow : MonoBehaviour {
  [SerializeField]
  private CanvasGroup _canvasGroup;
  [SerializeField]
  private TextMeshProUGUI _title;
  [SerializeField]
  private TextMeshProUGUI _description;
  [SerializeField]
  private Image  _image;
  [SerializeField]
  private Button _close;
  
  private void Awake() {    
    Events.Inventory.OpenItemDescription += OpenInventoryWindow;
    _close.onClick.AddListener(CloseInventoryWindow);
    gameObject.SetActive(false);
  }

  private void OnDestroy() {
    Events.Inventory.OpenItemDescription -= OpenInventoryWindow;

  }

  private void CloseInventoryWindow() {
    gameObject.SetActive(false);
  }

  public void OpenInventoryWindow (Item item) {
    _title.text = item.Title;
    _description.text = item.Description;
    _image.sprite = item.Image;
    
    _canvasGroup.alpha = 0;
    
    gameObject.SetActive(true);
    
    _canvasGroup.DOFade(1, 0.3f).SetEase(Ease.OutSine);;
  }
}