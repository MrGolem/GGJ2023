using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenInventrory : MonoBehaviour {
    [SerializeField]
    private Button _button;
    
    void Start()
    {
        _button.onClick.AddListener(()=> Events.Inventory.OpenInventory?.Invoke());
    }
}
