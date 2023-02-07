using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ChoseVaraiant/OpenFightScene")]
public class ChooseVariantFight : ChooseVariant {
  [SerializeField]
  private List<CharacterStatsConfig> characters;
  
  public override void Use() {
    var character = characters[Random.Range(0, characters.Count)];
    
    Events.Fight.StartFight(new Character(character));
    Events.Choose.CloseChooseWindow?.Invoke();
  }
}