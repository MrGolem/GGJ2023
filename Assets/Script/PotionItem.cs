using UnityEngine;

[CreateAssetMenu(menuName = "Item/Usable/Potion")]
public class PotionItem : ActionItem {
  [SerializeField]
  private int HealCount;
  
  public override void Use() {
    Debug.Log("I Heal some hp");
    Game.FightData._playerCharacter.ChangeHealthBy(HealCount);
    Game.Player.Inventory.ActionItems.Remove(this);
  }
}