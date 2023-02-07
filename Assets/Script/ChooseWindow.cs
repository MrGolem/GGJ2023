using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
public class ChooseWindow : MonoBehaviour {
  [SerializeField]
  private CanvasGroup _canvasGroup;
  
  [SerializeField, Space, Header("Main Container")]
  private GameObject _mainContainer;
  [SerializeField]
  private TextMeshProUGUI _title;
  [SerializeField]
  private TextMeshProUGUI _description;
  [SerializeField]
  private Image  _image;
  [SerializeField]
  private List<ChoseButton> _choseButtons;
  
  [SerializeField, Space, Header("Next Container")]
  private GameObject _nextContainer;
  [SerializeField]
  private TextMeshProUGUI _nextTitle;
  [SerializeField]
  private TextMeshProUGUI _nextDescription;
  [SerializeField]
  private ChoseButton _nextButton;

  private void Awake() {
    Events.Choose.OpenChooseWindow += OpenChooseWindow;
    Events.Choose.CloseChooseWindow += CloseChooseWindow;
    gameObject.SetActive(false);
  }

  private void OnDestroy() {
    Events.Choose.OpenChooseWindow -= OpenChooseWindow;
    Events.Choose.CloseChooseWindow -= CloseChooseWindow;
  }

  private void CloseChooseWindow() {
    gameObject.SetActive(false);
  }

  public void OpenChooseWindow (ChooseAction chooseAction) {
    
    OpenMainChose(chooseAction);
  }

  private void OpenMainChose(ChooseAction chooseAction) {
    _nextContainer.gameObject.SetActive(false);
    
    _title.text = chooseAction.Title;
    _description.text = chooseAction.MainDescription;
    _image.sprite = chooseAction.Image;

    foreach (var choseButton in _choseButtons) {
      choseButton.gameObject.SetActive(false);
    }

    for (int index = 0; index <  chooseAction.ChooseVariants.Count; index++) {
      ChoseButton choseButton = _choseButtons[index];
      choseButton.InitText($"{index + 1}. {chooseAction.ChooseVariants[index].VariantName}");
      
      choseButton.gameObject.SetActive(true);
      
      choseButton.OnButtonClickAction = () => {
        var i = _choseButtons.IndexOf(choseButton);
        _mainContainer.gameObject.SetActive(false);

        _nextTitle.text = chooseAction.ChooseVariants[i].AfterChooseConfig.Title;
        _nextDescription.text = chooseAction.ChooseVariants[i].AfterChooseConfig.String;

        _nextButton.InitText($"1. {chooseAction.ChooseVariants[i].AfterChooseConfig.VariantName}");
        _nextButton.OnButtonClickAction = () => { chooseAction.ChooseVariants[i].Use(); };
        _nextContainer.gameObject.SetActive(true);
      };
    }

    _mainContainer.SetActive(true);
    
    _canvasGroup.alpha = 0;
    
    gameObject.SetActive(true);
    
    _canvasGroup.DOFade(1, 0.3f).SetEase(Ease.OutSine);
  }
}