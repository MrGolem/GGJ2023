using UnityEngine;
[CreateAssetMenu(menuName = "ChoseVaraiant/OpenFightScene")]
public class ChooseVariantFight : ChooseVariant {
  [SerializeField]
  private CharacterStatsConfig character;
  
  public override void Use() {
    Debug.LogError("AAAA");
    Events.Fight.StartFight(new Character(character));
    Events.Choose.CloseChooseWindow?.Invoke();
  }
}