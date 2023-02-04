using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ChoseVaraiant/OpenMoveScene")]
public class ChooseVariantMove : ChooseVariant
{
    public override void Use()
    {
        Debug.Log("Lets just go");
        Events.Choose.CloseChooseWindow?.Invoke();
        Events.RollDiceEvent.WaitForRoll?.Invoke();
    }
}
