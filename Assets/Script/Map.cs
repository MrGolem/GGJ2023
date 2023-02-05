using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class Map : MonoBehaviour {
  [SerializeField]
  private List<Node> _nodes = new List<Node>();
  [SerializeField]
  private List<ChooseAction> _normalActions;  
  [SerializeField]
  private List<ChooseAction> _final;  
  [SerializeField]
  private List<ChooseAction> _bossActions;

  private int _playerPosition;

  public void Start() {
    for (int index = 0; index < _nodes.Count; index++) {
      Node node = _nodes[index];
      node.PositionNumber = index;
    }

    Events.MoveOnMap.EndMove += OpenChooseWindow;
    Events.RollDiceEvent.WaitForRoll += OpenAllNextNodes;
    OpenAllNextNodes();
  }

  private void OnDestroy() {
    Events.MoveOnMap.EndMove -= OpenChooseWindow;
    Events.RollDiceEvent.WaitForRoll -= OpenAllNextNodes;
  }

  public void OpenAllNextNodes() {
    StartCoroutine(OpenCoroutine());
  }

  private IEnumerator OpenCoroutine() {
    foreach (var node in _nodes[_playerPosition]._nextNodes) {
      yield return new WaitForSeconds(0.3f);
      if(node.InUse) continue;
      node.Open();
    }
  }

  public Node MapGetNextNode() {
    var openedNodes = _nodes[_playerPosition]._nextNodes;

    Node lastNode = _nodes[_playerPosition];
    lastNode.Lock();
    
    Node node = lastNode.GetNextPoint();
    
    _playerPosition = node.PositionNumber;
    Game.Player.Path.Add(_playerPosition);

    openedNodes.Remove(node);

    foreach (var openedNode in openedNodes) {
      openedNode.Hide();
    }
    
    return node;
  }

  private void OpenChooseWindow() {
    var nodeType = _nodes[_playerPosition].NodeType;

    switch (nodeType) {
      case NodeType.Normal:
        Events.Choose.OpenChooseWindow?.Invoke(_normalActions[Random.Range(0, _normalActions.Count)]);
        break;
      case NodeType.Boss:
        Events.Choose.OpenChooseWindow?.Invoke(_bossActions[Random.Range(0, _bossActions.Count)]);
        break;
      case NodeType.Final:
        Events.Choose.OpenChooseWindow?.Invoke(_final[Random.Range(0, _final.Count)]);
        break;
      default:
        Events.Choose.OpenChooseWindow?.Invoke(_normalActions[Random.Range(0, _normalActions.Count)]);
        break;
    }
  }
}