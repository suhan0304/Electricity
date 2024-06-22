using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BlockRepository", menuName = "ScriptableObjects/BlockRepository", order = 0)]
public class BlockRepository : ScriptableObject
{
    public List<GameObject> blockPrefabs;

    public Dictionary<string, int> blockDictionary;

    public void OnEnable() {
        InitializeDictionary();
    }

    public void InitializeDictionary() {
        blockDictionary = new Dictionary<string, int>();

        foreach (var prefab in blockPrefabs) {
            if(prefab != null) {
                blockDictionary[prefab.name] = blockDictionary.Count;
            }
        }
    }

    public int GetPlockType(string prefabName) {
        if (blockDictionary.TryGetValue(prefabName, out var typeNo)) {
            return typeNo;
        }

        Debug.LogWarning($"Prefab with name {prefabName} not found!");
        return -1;
    }
}