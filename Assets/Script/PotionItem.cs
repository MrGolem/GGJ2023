using UnityEngine;

[CreateAssetMenu(menuName = "Item/Usable/Potion")]
public class PotionItem : ActionItem {
  [SerializeField]
  private int HealCount;
  
  public override void Use() {
    Debug.Log("I Heal some hp");
  }
}