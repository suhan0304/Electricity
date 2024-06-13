using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PrefabRepository", menuName = "ScriptableObjects/PrefabRepository", order = 0)]
public class PrefabRepository : ScriptableObject {
    public List<GameObject> prefabs;

    private Dictionary<string, GameObject> prefabDictionary;

    private void OnEnable() {
        
    }

    private void InitializeDictionary() {
        prefabDictionary = new Dictionary<string, GameObject>();

        foreach (var prefab in prefabs) {
            if(prefab != null) {
                prefabDictionary[prefab.name] = prefab;
            }
        }
    }

    public GameObject GetPrefab(string prefabName) {
        if (prefabDictionary.TryGetValue(prefabName, out var prefab)) {
            return prefab;
        }

        Debug.LogWarning($"Prefab with name {prefabName} not found!");
        return null;
    }
}