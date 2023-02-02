using System;
public class Events {
  public class StateControllerEvent {
    public static Action<GameStateEnum> StartState;
  }
   
  public class RollDiceEvent {
    public static Action RollDice;
  }

  public class MoveOnMap {
    public static Action StartMove;
    public static Action EndMove;
  }
}