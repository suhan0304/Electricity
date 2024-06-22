using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BlockRepository", menuName = "ScriptableObjects/BlockRepository", order = 0)]
public class BlockRepository : ScriptableObject
{
    public List<blockData> blockDatas;
    public Dictionary<int, GameObject> blockDictionary;

    private void OnValidate() {
        UpdateBlockData();   
        UpdateDictionary(); 
    }

    public void UpdateBlockData() {
        for (int i = 0 ; i < blockDatas.Count; i++) {
            var data = blockDatas[i];
            if (data.prefab != null) {
                data.name = data.prefab.name;
                data.blockType = i;
            }
        }
    }    
    
    public void UpdateDictionary()
    {
        blockDictionary.Clear();
        foreach (var data in blockDatas)
        {
            if (data.prefab != null)
            {
                blockDictionary[data.blockType] = data.prefab;
            }
        }
    }
}