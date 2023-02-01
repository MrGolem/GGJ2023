using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Random;

public class PlayerController : MonoBehaviour
{
	public GameObject PlayerControllerChip;
	public DungeonController dungeonController;
	public int PlayerMaxHealth, PlayerCurrentHealth, PlayerArmor, PlayerCurentDamage;
	public Vector2 playerDamageRange;
    void Start()
    {
		
    }
	
	void OnDiceTossUp()
	{
		//PlayerCurentDamage = Random.Range( PlayerDamageRange.x, PlayerDamageRange.y);		
	}
}
