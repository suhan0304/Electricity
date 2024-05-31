using UnityEngine;

public class Validator : MonoBehaviour
{
    public bool ValidateInitialization()
    {

        // Validation Initialization GameObject in GameManager
        if (GameManager.Instance.endPoint == null)
        {
            Debug.Log("Error 02 : 01 - InitializationError");
            return false;
        }

        // Validation Initialization Material in GameManager
        if (GameManager.Instance.PillarMaterial == null)
        {
            Debug.Log("Error 02 : 02 - InitializationError");
            return false;
        }

        return true;
    }
}
