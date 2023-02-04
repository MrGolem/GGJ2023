using UnityEngine;

[CreateAssetMenu(menuName = "Item/Unusable/Weapon")]
public class WeaponItem : Item {
  private Vector2 _damage;
  
  public (int,int) Damage => ((int) _damage.x ,(int) _damage.y);
}