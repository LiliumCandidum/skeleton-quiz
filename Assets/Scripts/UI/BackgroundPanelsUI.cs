using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BackgroundPanelsUI : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.OnStateChanged += OnStateChanged;
        gameObject.SetActive(false);
    }

    private void OnStateChanged(object sender, System.EventArgs e)
    {
        gameObject.SetActive(GameManager.Instance.IsGameRunning());
    }
}
