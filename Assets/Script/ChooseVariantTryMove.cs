using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

[CreateAssetMenu(menuName = "ChoseVaraiant/OpenMoveTryScene")]
public class ChooseVariantTryMove : ChooseVariant
{
    public override void Use()
    {
        Debug.Log("Lets try escape");
        Events.MoveOnMap.StartMove();
        Events.RollDiceEvent.WaitForRoll?.Invoke();
    }
}
