using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance; // Singleton Pattern

    private void Awake() // For singleton Ma
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
        blockToBuild = standardBlockPrefab; //For Test
    }

    private GameObject blockToBuild; // blockToBuild GameObject

    public GameObject GetBlockToBuild() // return blockToBuild;
    {
        return blockToBuild;
    }
}
