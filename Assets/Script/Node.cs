using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour {
  [SerializeField]
  public List<Node> _nextNodes;
  [SerializeField]
  private NodeType _nodeType;
  
  private ParticleSystem _openParticle;
  private SpriteRenderer _spriteRenderer;

  public bool InUse;
  private Tween _fadeTween;
  

  public void Open() {
    _openParticle = GetComponentInChildren<ParticleSystem>();
    _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    _fadeTween?.Kill();
    _fadeTween = _spriteRenderer.DOFade(1, 0.5f);
    _openParticle.Play();
  }

  public void Hide() {
    _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    _fadeTween?.Kill();
    _fadeTween = _spriteRenderer.DOFade(0, 0.5f);
  }
  
  
  public Node GetNextPoint() {
    var diceNumber = Game.Dice.CurrentDiceCount;
    var nods = _nextNodes;

    for (int index = nods.Count - 1; index >= 0; index--) {
      Node node = nods[index];

      if (node.InUse) {
        nods.Remove(node);
      }
    }

    var nodsCount = nods.Count;
    return _nextNodes[diceNumber % nodsCount];
  }

  public void Lock() {   
    _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

    InUse = true;
    _spriteRenderer.DOColor(new Color(1f,1,1,0.5f), 0.5f);
  }

  public int PositionNumber { get; set; }
  public NodeType NodeType { get; set; }
}

public enum NodeType {
  Normal, Boss
}
