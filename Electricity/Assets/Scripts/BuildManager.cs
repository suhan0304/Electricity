using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance; // Singleton Pattern

    private void Awake() // For singleton Pattern
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public GameObject standardBlockPrefab;

    private void Start()
    {
        blockToBuild = standardBlockPrefab; //For Test - 초기값 : standardBlock으로 나중에 UI에서 블럭 선택해서 건설하도록
    }

    private GameObject blockToBuild; // blockToBuild GameObject

    public GameObject GetBlockToBuild() // return blockToBuild;
    {
        return blockToBuild;
    }
}
