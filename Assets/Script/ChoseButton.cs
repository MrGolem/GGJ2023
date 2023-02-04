using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
public class ChoseButton : MonoBehaviour {
  public Action OnButtonClickAction;
  
  [SerializeField]
  private Button _button;
  [SerializeField]
  private TextMeshProUGUI _name;

  public void InitText (string text) {
    _name.text = text;
  }
  
  private void Awake() {
   _button.onClick.AddListener(OnButtonClick);
  }

  private void OnDestroy() {
    _button.onClick.RemoveListener(OnButtonClick);
  }

  private void OnButtonClick() {
    OnButtonClickAction?.Invoke();
  }
}