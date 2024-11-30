using System;
using UnityEngine;

public class BoneHandler : MonoBehaviour
{
    void OnMouseDown()
    {
        ExploreManager.Instance.OnBoneClick(gameObject.GetComponent<Renderer>(), transform.parent);
    }
}
