using UnityEngine;
using UnityEngine.SceneManagement;
[CreateAssetMenu(menuName = "ChoseVaraiant/Win")]
public class GoToMainMenu : ChooseVariant
{
  public override void Use() {
    SceneManager.LoadSceneAsync("MainMenu");
  }
}