using UnityEngine;
[CreateAssetMenu(menuName = "ChoseVaraiant/OpenFightScene")]
public class ChooseVariantFight : ChooseVariant {

  public override void Use() {
    Debug.Log("Here will be go to scene");
    Debug.Log("Можешь тут роботи перевірки на кубік щоб перевірити якесь своє значення ( наприклад скіп)" + Game.Dice.CurrentDiceCount);
    Events.Choose.CloseChooseWindow?.Invoke();
  }
}