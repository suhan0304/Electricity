using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class buildButton : MonoBehaviour
{    
    private TMP_Text blockNameText;
    private TMP_Text blockCountText;

    private blockData _blockData;
    private int _blockCount;

    private BuildMenu buildMenu;

    private void OnEnable() {
        buildMenu = GetComponentInParent<BuildMenu>();    
    }

    public blockData BlockData {
        get { 
            return _blockData; 
            }
        set { 
            _blockData = value; 
            blockNameText.text = value.blockName;
            }
    }

    public int BlockCount {
        get { 
            return _blockCount;
        }
        set {
            _blockCount = value;
            blockCountText.text = _blockCount.ToString();
            if (_blockCount != 0) {
                GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnClickBlockButton(_blockData));
            }
        }
    }

    public void OnClickBlockButton(blockData blockData) {
        buildMenu.SelectBlock(blockData.blockType);
    }
}
