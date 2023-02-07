using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;
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

public class ChooseWindow : MonoBehaviour {
  [SerializeField]
  private List<ChooseAction> _normalActions;

  [SerializeField]
  private TextMeshProUGUI _Title;
  [SerializeField]
  private string _description;
  [SerializeField]
  private Image  _image;

  [SerializeField]
  private List<ChoseButton> _choseButtons;

}

public class ChoseButton : MonoBehaviour {
  [SerializeField]
  private Button _button;
}

[CreateAssetMenu]
public class ChooseAction : ScriptableObject {
  public string Title;
  public string String;
  public Image Image;
  public List<ChooseVariant> ChooseVariants;
}

[CreateAssetMenu]
public class AfterChoose : ScriptableObject {
  public string Title;
  public string String;
}

[CreateAssetMenu]
public class ChooseVariant : ScriptableObject {
  public AfterChoose AfterChooseConfig;
  
  public virtual void Use() {
    
  }
}