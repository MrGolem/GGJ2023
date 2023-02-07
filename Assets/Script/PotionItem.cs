using UnityEngine;

[CreateAssetMenu(menuName = "Item/Usable/Potion/Heal")]
public class PotionItem : ActionItem {
    [SerializeField]
  private int HealStats;
  
  public override void Use() {
    Debug.Log("I Heal some hp");
  }
}