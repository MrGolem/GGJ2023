using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public class CharacterView : MonoBehaviour {
  [SerializeField]
  private Image _image;
  [SerializeField]
  private Image _highLight;
  [SerializeField]
  private UnitType _unitType;

  public Action OnAttackComplete;

  private Sequence _dealDamage;
  private Sequence _HighlightDamage;
  public Character _characterStatsConfig;

  public void SetCharacter(Character character) {
    gameObject.SetActive(true);
    _characterStatsConfig = character;
    _image.sprite = character._characterStatsConfig.Image;
  }
  
  private void Awake() {
    _highLight.color = new Color(1, 1, 1, 0);
  }

  public void DealDamage() {
    _dealDamage?.Kill();
    _dealDamage = DOTween.Sequence();

    _dealDamage.Append(_image.transform.DOShakePosition(0.5f, 5f));
    _dealDamage.AppendCallback(() => {
      Events.Fight.DealDamage?.Invoke(_unitType,  (int) Mathf.Lerp(1, 6, (_unitType == UnitType.Player ? Game.Dice.CurrentDiceCount : Random.Range(1, 6)) / 6f));
    });

    _dealDamage.AppendInterval(0.5f);
    _dealDamage.OnKill(() => OnAttackComplete?.Invoke());
  }

  public void GetDamage(int damage) {
    
    _HighlightDamage?.Kill();
    _HighlightDamage = DOTween.Sequence();

    _characterStatsConfig.ChangeHealthBy(-damage);
    
    _HighlightDamage.Append(_highLight.DOFade(1f, 0.25f).SetEase(Ease.OutSine));
    _HighlightDamage.Join(_image.transform.DOScale(0.8f, 0.25f).SetEase(Ease.Linear));
    _HighlightDamage.Append(_highLight.DOFade(0, 0.25f).SetEase(Ease.InSine));
    _HighlightDamage.Join(_image.transform.DOScale(1, 0.25f).SetEase(Ease.Linear));
  }
  
}