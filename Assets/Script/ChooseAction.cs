using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ChooseAction : ScriptableObject {
  public string Title;
  public string MainDescription;
  public Sprite Image;
  public List<ChooseVariant> ChooseVariants;
}