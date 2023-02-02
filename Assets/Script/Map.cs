using System.Collections.Generic;
using UnityEngine;
public class Map : MonoBehaviour {
  [SerializeField]
  private List<Node> _nodes = new List<Node>();
   
  private int _playerPosition;

  public void Start() {
    for (int index = 0; index < _nodes.Count; index++) {
      Node node = _nodes[index];
      node.PositionNumber = index;
    }
  }

  public Node MapGetNextNode() { 
    Node node = _nodes[_playerPosition].GetNextPoint();
    _playerPosition = node.PositionNumber;
    Game.Player.Path.Add(_playerPosition);
    return node;
  }
}