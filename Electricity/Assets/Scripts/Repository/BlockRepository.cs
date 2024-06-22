using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BlockRepository", menuName = "ScriptableObjects/BlockRepository", order = 0)]
public class BlockRepository : ScriptableObject
{
    [Serializable]
    public class BlockData {
        public GameObject prefab;
        public Sprite spriteImage;
        public int blockType;
        public string blockName;
    }

    public List<BlockData> blockDatas;
    public Dictionary<int, GameObject> blockDictionary;

    private void OnValidate() {
        UpdateBlockData();   
        UpdateDictionary(); 
    }

    public void UpdateBlockData() {
        for (int i = 0 ; i < blockDatas.Count; i++) {
            var data = blockDatas[i];
            if (data.prefab != null) {
                data.blockName = data.prefab.name;
                data.blockType = i;
            }
        }
    }    
    
    public void UpdateDictionary()
    {
        if (blockDictionary == null)
            blockDictionary = new Dictionary<int, GameObject>();

        Dictionary<int, GameObject> newDictionary = new Dictionary<int, GameObject>();
        foreach (var data in blockDatas)
        {
            if (data.prefab != null && !newDictionary.ContainsKey(data.blockType))
            {
                newDictionary[data.blockType] = data.prefab;
            }
        }

        blockDictionary = newDictionary;
    }

    public GameObject GetPrefabToType(int type) {
        return blockDictionary[type];
    }
}