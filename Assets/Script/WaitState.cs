public class WaitState : State {
  public override void Init() {
    Events.RollDiceEvent.WaitForRoll?.Invoke();
  }

  public override GameStateEnum StateEnum { get; set; } = GameStateEnum.Wait;
}

public class FightWaitState : State {
  public override void Init() {
    Events.Fight.WaitForFightRoll?.Invoke();
  }

  public override GameStateEnum StateEnum { get; set; } = GameStateEnum.FightWait;
}

public class PlayerTeamAttack : State {
  public override void Init() {
    Events.Fight.PlayerTeamAttack?.Invoke();
  }

  public override GameStateEnum StateEnum { get; set; } = GameStateEnum.PlayerTeamAttack;
}

public class EnemyTeamAttack : State {
  public override void Init() {
    Events.Fight.EnemyTeamAttack?.Invoke();
  }

  public override GameStateEnum StateEnum { get; set; } = GameStateEnum.PlayerTeamAttack;
}