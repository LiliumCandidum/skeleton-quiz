using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HomeButtonsScript : MonoBehaviour
{
    public void OnPlayClick() {
        Debug.Log("clicked play!");
    }

    public void OnInfoClick() {
        Debug.Log("clicked info!");
    }

    public void OnLearnClick() {
        Debug.Log("clicked learn!");
    }
}
