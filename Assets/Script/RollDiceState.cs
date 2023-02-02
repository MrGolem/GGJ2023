public class RollDiceState : State {
  public override void Init() {
    Events.RollDiceEvent.RollDice?.Invoke();
  }

  public override GameStateEnum StateEnum { get; set; } = GameStateEnum.RollDice;
}