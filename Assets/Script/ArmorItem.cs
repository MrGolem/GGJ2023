using UnityEngine;

[CreateAssetMenu(menuName = "Item/Unusable/Armor")]
public class ArmorItem : Item {
    [SerializeField]
    private int DamageBlocked;
  public int Armor { get; set; }
}