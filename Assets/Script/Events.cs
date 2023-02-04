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
  
  public class Choose {
    public static Action<ChooseAction> OpenChooseWindow;
    public static Action CloseChooseWindow;
  }
}