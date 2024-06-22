using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using TMPro;

public class BuildButton : MonoBehaviour
{    
    private BuildMenu buildMenu;

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

    void Start() {
        buildMenu = GetComponentInParent<BuildMenu>();
    }

    public void OnClickBlockButton() {
        buildMenu.SelectedButton = this.gameObject;
        buildMenu.SelectBlock(BlockInventory.blockData.blockType);
    }
}
