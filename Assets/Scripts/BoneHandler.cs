using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneHandler : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("ON MOUSE DOWN");
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}
