using System;
public class Events {
  public class StateControllerEvent {
    public static Action<GameStateEnum> StartState;
  }
   
  public class RollDiceEvent {
    public static Action WaitForRoll;
    public static Action RollDice;
  }

  public class Fight {
    public static Action<Character> StartFight;
    
    public static Action WaitForFightRoll;
    public static Action PlayerTeamAttack;
    public static Action EnemyTeamAttack;

    public static Action OpenWinMenu;
    public static Action CloseWinMenu;
    
    public static Action OpenLoseMenu;
    public static Action CloseLoseMenu;

    public static Action UpdateStatsUI;
    
    public static Action<UnitType, int> DealDamage;
  }

  public class MoveOnMap {
    public static Action StartMove;
    public static Action EndMove;
  }

  public class Inventory {
    public static Action<Item> OpenItemDescription;
    public static Action<Item> OpenRemoveItem;
    public static Action OpenInventory;
    public static Action<Item> AddItem;
    public static Action<Item> RemoveItem;
  }
  
  public class Choose {
    public static Action<ChooseAction> OpenChooseWindow;
    public static Action CloseChooseWindow;
  }
}