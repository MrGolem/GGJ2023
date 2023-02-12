using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMessageSpawner : MonoBehaviour
{
    [SerializeField]
    private Vector2 _initialPosition;

    [SerializeField]
    private GameObject _messagePrefab;

    public void SpawnMessage(string msg)
    {
        var msgObj = Instantiate(_messagePrefab, GetSpawnPoint(), Quaternion.identity, transform.parent.transform);     
        var inGameMessage = msgObj.GetComponent<FloatingMessage>();
        inGameMessage.SetMessage(msg);
    }
    private Vector3 GetSpawnPoint()
    {
        return transform.position + (Vector3) _initialPosition;
    }
}
