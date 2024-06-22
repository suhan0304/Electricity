using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BlockRepository", menuName = "ScriptableObjects/BlockRepository", order = 0)]
public class BlockRepository : ScriptableObject
{
    [Serializable]
    public class blockData {
        public GameObject prefab;
        public Sprite spriteImage;
        public int type;
        public string name;
    }

    public List<blockData> blockDatas;

    private void OnValidate() {
        UpdateBlockDate();    
    }

    private void UpdateBlockDate() {
        for (int i = 0 ; i < blockDatas.Count; i++) {
            var data = blockDatas[i];
            if (data.prefab != null) {
                data.name = data.prefab.name;
                data.type = i;
            }
        }
    }

}