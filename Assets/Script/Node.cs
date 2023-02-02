using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
  [SerializeField]
  private List<Node> _nextNodes;
  [SerializeField]
  private NodeType _nodeType;

  public Node GetNextPoint() {
    var diceNumber = Game.Dice.CurrentDiceCount;
    var nodsCount = _nextNodes.Count;
    return _nextNodes[diceNumber % nodsCount];
  }

  public int PositionNumber { get; set; }
}

public enum NodeType {
  Normal, Boss
}
