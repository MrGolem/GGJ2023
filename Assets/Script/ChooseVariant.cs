using UnityEngine;


[CreateAssetMenu(menuName = "ChoseVaraiant/Base")]
public class ChooseVariant : ScriptableObject {
  public string VariantName;
  [SerializeField]
  protected AfterChoose _afterChooseConfig;
    public virtual AfterChoose AfterChooseConfig => _afterChooseConfig;


  public virtual void Use()
  {
      
  }
}