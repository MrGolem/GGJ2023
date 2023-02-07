using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ChoseVaraiant/BossFight")]
public class ChooseVariantBossFight : ChooseVariant {
  [SerializeField]
  private List<CharacterStatsConfig> _bosses;
  
  public override void Use() {
    var character = _bosses[Random.Range(0, _bosses.Count)];
    
    Events.Fight.StartFight(new Character(character));
    Events.Choose.CloseChooseWindow?.Invoke();
  }
}