using UnityEngine;


[CreateAssetMenu(menuName = "ChoseVaraiant/Base")]
public class ChooseVariant : ScriptableObject {
  public string VariantName;
  
  public AfterChoose AfterChooseConfig;
  
  public virtual void Use() {
    
  }
}