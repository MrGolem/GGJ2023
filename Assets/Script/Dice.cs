using UnityEngine;
public class Dice {
  public int CurrentDiceCount;
   
  public int RollDice() {
    CurrentDiceCount = Random.Range(1, 7);
    return CurrentDiceCount;
  }
}