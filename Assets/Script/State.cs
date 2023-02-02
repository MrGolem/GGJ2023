public abstract class State {
  public virtual void Init() {}
  public virtual void Update() {}
  public virtual void OnStepEnd() {}
  public abstract GameStateEnum StateEnum { get; set; }
}