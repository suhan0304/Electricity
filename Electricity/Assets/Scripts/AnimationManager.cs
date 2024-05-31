using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField]
    public Animator endPointAnim = null;

    private void Awake()
    {
        endPointAnim = GameManager.Instance.endPoint.GetComponent<Animator>();
    }

    private void Start()
    {

    }
}
