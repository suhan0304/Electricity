using UnityEngine;
using System.Collections.Generic;

public class TransparentBlockManager : MonoBehaviour
{
    [Header("Select to Build Block")]
    public int selectedBlockType = -1;

    public static TransparentBlockManager Instance;
    // for signleton pattern 

    [System.Serializable]
    public class TransparentBlock {
        public int blockType; // block type (int) -> for block choose
        public GameObject blockObject;
    }

    public List<TransparentBlock> transparentBlocks;
    public Dictionary<int, GameObject> transparentBlockDictionary;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            InitializeDictionary();
        }
        else {
            Debug.LogWarning("Error - Only 1 instance - TransparentBlockManager.");
            Destroy(gameObject);
            return;
        }
    }

    /// Initialize Transparent Block Dictionary
    private void InitializeDictionary() {
        transparentBlockDictionary = new Dictionary<int, GameObject>();

        foreach (var block in transparentBlocks) {
            block.blockObject.SetActive(false); // All transparent block object Hide.
            transparentBlockDictionary[block.blockType] = block.blockObject; // mapping dict[blockType(int)] = blockObject
        }
    }

    // Set Selected Block Type ( Hide other Type transparent Block )
    public void SetSelectedBlockType(int blockType) {
        selectedBlockType = blockType;
        HideTransparnetBlock();
    }

    /// Show Transparent Block ( When Mouse On )
    public void ShowTransparentBlock(Vector3 position, float blockHeight) {
        if (selectedBlockType == -1) // not select
            return;
        if (transparentBlockDictionary.TryGetValue(selectedBlockType, out var block)) {
            block.transform.position = position + 
                new Vector3(0, blockHeight + (BuildManager.Instance.blockToBuild.transform.localScale.y /2), 0);
            block.SetActive(true);
        }
    }

    /// Hide Transparent Block ( When Mouse Exit )
    public void HideTransparnetBlock() {
        if (selectedBlockType == -1) // not select
            return;

        foreach (var block in transparentBlocks) {
            block.blockObject.SetActive(false);
        }
    }
}
