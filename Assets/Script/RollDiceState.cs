public class RollDiceState : State {

  public override void Init() {
    RollDice();
    Events.RollDiceEvent.RollDice?.Invoke();
  }

  private void RollDice() {
    Game.Dice.RollDice();
  }

  public override GameStateEnum StateEnum { get; set; } = GameStateEnum.RollDice;
}