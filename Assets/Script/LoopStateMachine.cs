using System;
using System.Collections.Generic;
public class LoopStateMachine {
  private Dictionary<Type, State> _states = new Dictionary<Type, State>();

  private Dictionary<GameStateEnum, Type> _statesGame = new Dictionary<GameStateEnum, Type>();
   
      
  private State _currentState;
  public LoopStateMachine() {
    _statesGame.Add(GameStateEnum.Wait, typeof(WaitState));
    _statesGame.Add(GameStateEnum.WalKOnMap, typeof(WalkOnMap));
    _statesGame.Add(GameStateEnum.RollDice, typeof(RollDiceState));
    _statesGame.Add(GameStateEnum.FightWait, typeof(FightWaitState));
    _statesGame.Add(GameStateEnum.PlayerTeamAttack, typeof(PlayerTeamAttack));
    _statesGame.Add(GameStateEnum.EnemyTeamAttack, typeof(EnemyTeamAttack));
      
    //  _statesGame.Add(GameStateEnum.Choose, typeof());
    _states.Add(typeof(WaitState),new WaitState());
    _states.Add(typeof(RollDiceState),new RollDiceState());
    _states.Add(typeof(WalkOnMap),new WalkOnMap());
    _states.Add(typeof(FightWaitState),new FightWaitState());
    _states.Add(typeof(PlayerTeamAttack),new PlayerTeamAttack());
    _states.Add(typeof(EnemyTeamAttack),new EnemyTeamAttack());

    Events.StateControllerEvent.StartState = StartState;
  }

  public void StartState(GameStateEnum gameStateEnum){
    _currentState?.OnStepEnd();
    _currentState = _states[_statesGame[gameStateEnum]];
    _currentState.Init();
  }
   
}
