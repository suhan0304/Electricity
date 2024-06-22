using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 0)]
public class LevelData : ScriptableObject
{
    public BlockRepository blockRepository;

    public int level; 
    public List<BlockRepository.BlockData> blockDatas;
    public Dictionary<int, int> blockCounts;

    public void Initialize()
    {
        if (blockRepository != null)
        {
            blockDatas = new List<BlockRepository.BlockData>(blockRepository.blockDatas);

            blockCounts = new Dictionary<int, int>();
            foreach (var blockData in blockRepository.blockDatas)
            {
                blockCounts[blockData.blockType] = 0;
            }
        }
        else
        {
            Debug.LogWarning("LevelData: blockRepository is not assigned!");
        }
    }
}
