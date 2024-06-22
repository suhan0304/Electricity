using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BlockRepository", menuName = "ScriptableObjects/BlockRepository", order = 0)]
public class BlockRepository : ScriptableObject
{
    [SerializeField]
    public class blockData {
        public GameObject prefab;
        public Sprite spriteImage;
        public int type;
        public string name;
    }

    public List<blockData> blackDatas;

    public Dictionary<string, blockData> blockDictionary;

    public void OnEnable() {
        InitializeDictionary();
    }

    public void InitializeDictionary() {
        blockDictionary = new Dictionary<string, blockData>();

        foreach (var blockData in blackDatas) {
            if(blockData != null && blockData.prefab != null) {
                blockDictionary[blockData.prefab.name] = blockData;
            }
        }
    }

    public blockData GetBlockData(string prefabName) {
        if (blockDictionary.TryGetValue(prefabName, out var blockData)) {
            return blockData;
        }

        Debug.LogWarning($"BlockData with prefab name {prefabName} not found!");
        return null;
    }
}