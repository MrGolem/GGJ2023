using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMessageSpawner : MonoBehaviour
{
    [SerializeField]
    private Vector2 _initialPosition;
    public GameObject FloatMessage;

    [SerializeField]
    private GameObject _messagePrefab;

    public void SpawnMessage(string msg)
    {

        //var msgObj = Instantiate(_messagePrefab, GetSpawnPoint(), Quaternion.identity);     Не працює сука   
        var msgObj = FloatMessage;
        msgObj.SetActive(true);
        var inGameMessage = msgObj.GetComponent<FloatingMessage>();
        inGameMessage.SetTimer();
        inGameMessage.SetMessage(msg);

    }
    private Vector3 GetSpawnPoint()
    {
        return transform.position + (Vector3) _initialPosition;
    }
}
