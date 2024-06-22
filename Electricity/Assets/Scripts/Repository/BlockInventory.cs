using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BlockInventory", menuName = "ScriptableObjects/BlockInventory", order = 0)]
public class BlockInventory : ScriptableObject
{
    public Dictionary<GameObject, int> blockDictionary;

    public void OnEnable() {
        InitializeDictionary();
    }
    
    public void InitializeDictionary() { 

    }
}
