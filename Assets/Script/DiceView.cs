using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiceView : MonoBehaviour {
    [SerializeField]
    private Button _button;
    [SerializeField]
    private GameObject _dice;

    [SerializeField]
    private Transform _topPoint;
    [SerializeField]
    private Transform _bottomPoint;

    [SerializeField]
    private List<Vector3> _diceSides;

    private bool IsCanUse = true;

    private void Awake() {
        _button.onClick.AddListener(OnButtonClicked);
        Events.RollDiceEvent.WaitForRoll += OnRollWait;
    }

    private void OnDestroy() {
        Events.RollDiceEvent.WaitForRoll -= OnRollWait;
    }

    private void OnRollWait() {
        IsCanUse = true;
    }

    private void OnButtonClicked() {
        if(!IsCanUse) return;
        
        Events.StateControllerEvent.StartState(GameStateEnum.RollDice);
        IsCanUse = false;

        _dice.transform.localRotation = Quaternion.Euler(_diceSides[Game.Dice.CurrentDiceCount - 1]);

        var moveSequence = DOTween.Sequence();
        moveSequence.Append(_dice.transform.DOLocalMove(_topPoint.localPosition, 0.5f).SetEase(Ease.OutSine));
        moveSequence.Append(_dice.transform.DOLocalMove(_bottomPoint.localPosition, 0.5f).SetEase(Ease.OutBounce));
        _dice.transform.DOShakeRotation(1f);
        

        moveSequence.OnComplete(() => {
            OnRollComplete();
        });
    }

    protected virtual void OnRollComplete() {
        Events.StateControllerEvent.StartState(GameStateEnum.WalKOnMap);
    }
}

public class ChooseScenario : MonoBehaviour {
    
}