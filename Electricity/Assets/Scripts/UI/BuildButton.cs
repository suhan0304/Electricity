using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using TMPro;
using UnityEngine.Rendering;

public class BuildButton : MonoBehaviour
{    
    [Header("Color")]
    public Image image;
    public Color InitialColor;
    public Color SelectedColor;

    private BuildMenu buildMenu;

    [Space(5)]
    [Header("TMP Text")]
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
        InitialColor = GetComponent<Image>().color;
        buildMenu = GetComponentInParent<BuildMenu>();
    }

    public void OnClickBlockButton() {
        if (buildMenu.SelectedButton != null) {
            buildMenu.SelectedButton.GetComponent<Image>().color = InitialColor;
        }

        if (buildMenu.SelectedButton == this.gameObject) {
            buildMenu.SelectedButton = null;
            buildMenu.DeselectBlock();
        }
        else {
            buildMenu.SelectedButton = this.gameObject;
            GetComponent<Image>().color = SelectedColor;
            buildMenu.SelectBlock(BlockInventory.blockData.blockType);
        }
    }

    public void buildSelectedBlock() {
        Debug.Log($"{this.name} - buildSelectedBlock");

        _blockInventory.blockCount--;
        blockCountText.text = _blockInventory.blockCount.ToString();

        if (_blockInventory.blockCount == 0) {
            GetComponent<Button>().interactable = false;
            buildMenu.DeselectBlock();
        }
    }
}
