using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMap : MonoBehaviour {
  [SerializeField]
  private Map _map;

  private void OnEnable() {
    Events.MoveOnMap.StartMove += MoveToNode;
  }

  private void OnDisable() {
    Events.MoveOnMap.StartMove -= MoveToNode;
  }

   
  public void MoveToNode() {
    Node nodeToMove = _map.MapGetNextNode();
    transform.DOMove(nodeToMove.transform.position, 1f).SetEase(Ease.OutQuint).OnKill(OnMoveComplete);
  }

  private void OnMoveComplete() {
    Events.MoveOnMap.EndMove?.Invoke();
  }
}