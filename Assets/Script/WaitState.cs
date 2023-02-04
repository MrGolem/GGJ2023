public class WaitState : State {
  public override void Init() {
    Events.RollDiceEvent.WaitForRoll?.Invoke();
  }

  public override GameStateEnum StateEnum { get; set; } = GameStateEnum.Wait;
}