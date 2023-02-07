using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiceView : MonoBehaviour {
    [SerializeField]
    private Button _button;

    [SerializeField]
    private TextMeshProUGUI _anim;

    private bool IsCanUse = true;

    private void Awake() {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked() {
        Events.StateControllerEvent.StartState(GameStateEnum.RollDice);
        IsCanUse = false;

        var sequence = DOTween.Sequence();

        sequence.AppendInterval(1f).OnComplete(() => {
            _anim.text = Game.Dice.CurrentDiceCount.ToString();
            Events.StateControllerEvent.StartState(GameStateEnum.WalKOnMap);
        });
    }
}

public class ChooseScenario : MonoBehaviour {
    
}