using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoseWindow : MonoBehaviour {
  [SerializeField]
  private CanvasGroup _canvasGroup;
  
  [SerializeField]
  private Button _choseButtons;

  private void Awake() {
    Events.Fight.OpenLoseMenu += OpenChooseWindow;
    Events.Fight.CloseLoseMenu += CloseChooseWindow;
    _choseButtons.onClick.AddListener(GoToMap);
    gameObject.SetActive(false);
  }

  private void OnDestroy() {
    Events.Fight.OpenLoseMenu -= OpenChooseWindow;
    Events.Fight.CloseLoseMenu -= CloseChooseWindow;
  }

  private void CloseChooseWindow() {
    gameObject.SetActive(false);
  }

  public void OpenChooseWindow () {
    OpenMainChose();
  }

  private void GoToMap() {
    SceneManager.LoadSceneAsync("MainMenu");
  }

  private void OpenMainChose() {

    _canvasGroup.alpha = 0;
    
    gameObject.SetActive(true);
    
    _canvasGroup.DOFade(1, 0.3f).SetEase(Ease.OutSine);
  }
}