using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

[CreateAssetMenu(menuName = "ChoseVaraiant/OpenMoveTryScene")]
public class ChooseVariantTryMove : ChooseVariant
{
    [SerializeField]
    private AfterChoose _aditionalAfterChoose;

    private bool isEscaped;

    public override AfterChoose AfterChooseConfig { get {
             isEscaped = Random.Range(0, 2) != 0;
            if (isEscaped)
            {
                return _afterChooseConfig;
            }//Втеча успішна
            else
            {
                return _aditionalAfterChoose;
            }
        } }
    public override void Use()
    {
        Debug.Log("Lets try escape");

        if (isEscaped)
        {
            Events.Choose.CloseChooseWindow?.Invoke();
        }//Втеча успішна
        else
        {
            Debug.Log("Attacked");
            Events.Choose.CloseChooseWindow?.Invoke();
        }
        Events.MoveOnMap.StartMove();
        Events.RollDiceEvent.WaitForRoll?.Invoke();
    }
}
