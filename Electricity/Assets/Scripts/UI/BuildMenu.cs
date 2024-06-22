using JetBrains.Annotations;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    BuildManager buildManager;
    public GameObject buttonPrefab;
    public LevelData levelData;

    void Start() {
        Debug.Log($"Level is {GameManager.Instance.mapLevel}");
        AddBtnsBuildMenu();
    }

    public void AddBtnsBuildMenu()
    {
        buildManager = BuildManager.Instance;
        buttonPrefab = Resources.Load<GameObject>("BuildButton");
        levelData = LevelDataManager.Instance.GetLevelData(GameManager.Instance.mapLevel);

        Debug.Log("Start Build Button UI");

        foreach(var blockInventory in levelData.blockInventories) {
            if (blockInventory.blockCount != 0) {
                GameObject BuildItem = Instantiate(buttonPrefab, transform);
                BuildItem.GetComponent<buildButton>().BlockInventory = blockInventory;
            }
        }
    }

}
