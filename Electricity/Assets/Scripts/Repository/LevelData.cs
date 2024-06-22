using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 0)]
public class LevelData : ScriptableObject
{
    public class BlockCount {
        public BlockRepository.blockData blockData;
        public int count;
    }

    [Serializable]
    public class Level {
        public int levelNumber;
        public List<BlockCount> blockCounts = new List<BlockCount>();

        public void Initialize(BlockRepository blockRepository) {
            blockCounts.Clear();
            foreach (var blockData in blockRepository.blockDatas) {
                blockCounts.Add(new BlockCount { blockData = blockData, count = 0 });
            }
        }
    }

    public BlockRepository blockRepository;
    public List<Level> levels = new List<Level>();

    private void OnValidate() {
        InitializeLevels();
    }

    public void InitializeLevels() {
        if (blockRepository == null) {
            Debug.LogWarning("BlockRepository is not assigned!");
            return;
        }
        
        foreach (var level in levels) {
            level.Initialize(blockRepository);
        }
    }    
    
    public void UpdateLevels() {
        InitializeLevels();
    }
}