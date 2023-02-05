public class DiceViewFight : DiceView {
  protected override void OnRollComplete() {
    Events.StateControllerEvent.StartState(GameStateEnum.PlayerTeamAttack);
  }
}