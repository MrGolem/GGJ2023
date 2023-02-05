using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class StatsPanel : MonoBehaviour {
  [SerializeField]
  private TextMeshProUGUI Damage;
  [SerializeField]
  private TextMeshProUGUI Armor;
  [SerializeField]
  private TextMeshProUGUI Health;
  [SerializeField]
  private Image _icon;

  [SerializeField]
  private UnitType _unitType;
  
  private void Start() {
    Events.Fight.UpdateStatsUI += UpdateUI;
    UpdateUI();
  }

  private void OnDestroy() {
    Events.Fight.UpdateStatsUI -= UpdateUI;
  }

  public void UpdateUI() {
    var character = _unitType == UnitType.Player ? Game.FightData._playerCharacter : Game.FightData._enemyCharacter;

    Damage.text = $"{character.Damage.Item1} - {character.Damage.Item2}";
    Armor.text = character.Armor.ToString();
    Health.text = character.CurrentHealth.ToString();

    _icon.sprite = character._characterStatsConfig.Icon;
  }
}