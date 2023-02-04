using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class Map : MonoBehaviour {
  [SerializeField]
  private List<Node> _nodes = new List<Node>();
  [SerializeField]
  private List<ChooseAction> _normalActions;  
  [SerializeField]
  private List<ChooseAction> _bossActions;

  private int _playerPosition;

  public void Start() {
    for (int index = 0; index < _nodes.Count; index++) {
      Node node = _nodes[index];
      node.PositionNumber = index;
    }

    Events.MoveOnMap.EndMove += OpenChooseWindow;
  }

  private void OnDestroy() {
    Events.MoveOnMap.EndMove -= OpenChooseWindow;
  }

  public Node MapGetNextNode() { 
    Node node = _nodes[_playerPosition].GetNextPoint();
    _playerPosition = node.PositionNumber;
    Game.Player.Path.Add(_playerPosition);
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
      default:
        Events.Choose.OpenChooseWindow?.Invoke(_normalActions[Random.Range(0, _normalActions.Count)]);
        break;
    }
  }
}