public class WalkOnMap : State {
  public override void Init() {
    Events.MoveOnMap.StartMove?.Invoke();
  }

  public override GameStateEnum StateEnum { get; set; } = GameStateEnum.WalKOnMap;
}