using UnityEngine;
using System.Collections.Generic;

public class TransparentBlockManager : MonoBehaviour
{
    public static TransparentBlockManager Instance;
    // for signleton pattern 

    [System.Serializable]
    public class Transparent {
        public string blockType; // block.name = blockType
        public GameObject blockPrefab;
    }

    public List<Block> transparentBlocks;
    private Dictionary<string, GameObject> blockDictionary;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    /// Initialize Transparent Block Dictionary
    private void InitializeDictionary() {
        blockDictionary = new Dictionary<string, GameObject>();

        foreach (var block in transparentBlocks) {
            block.gameObject.SetActive(false);
            blockDictionary[block.name] = block.gameObject;
        }
    }


    /// Show Transparent Block ( When Mouse On )
    public void ShowTransparentBlock(string blockType, Vector3 position) {
        if (blockDictionary.TryGetValue(blockType, out var block)) {
            block.transform.position = position;
            block.SetActive(true);
        }
    }

    /// Hide Transparent Block ( When Mouse Exit )
    public void HideTransparnetBlock(string blockType) {
        if (blockDictionary.TryGetValue(blockType, out var block)) {
            block.SetActive(false);
        }
    }
}
