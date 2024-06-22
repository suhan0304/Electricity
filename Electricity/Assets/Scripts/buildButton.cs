using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class buildButton : MonoBehaviour
{    
    public TMP_Text blockNameText;
    public TMP_Text blockCountText;

    private LevelData.BlockInventory _blockInventory;

    public LevelData.BlockInventory BlockInventory {
        get { 
            return _blockInventory; 
        }
        set {
            _blockInventory = value;
            blockNameText.text = _blockInventory.blockData.blockName;
            blockCountText.text = _blockInventory.blockCount.ToString();
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnClickBlockButton());
        }
    }

    public void OnClickBlockButton() {
        //buildMenu.SelectBlock(blockData.blockType);
        Debug.Log("Button!");
    }
}
