using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class DiceController : MonoBehaviour
{
	public GameObject dice;
	public DungeonController dungeonController;
    void Start()
    { 
        dungeonController.DicePoints = 1;
    }
	
	void OnDiceTossUp()
	{
		dungeonController.DicePoints = Random.Range( 1,7);		
	}
}
