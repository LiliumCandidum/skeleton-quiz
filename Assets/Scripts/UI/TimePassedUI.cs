using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimePassedUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI timePassedText;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnStateChanged += OnStateChanged;
        gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        int totSeconds = Mathf.CeilToInt(GameManager.Instance.GetGameTime());
        int minutes = (totSeconds % 3600) / 60;
        int seconds = totSeconds % 60;
        timePassedText.text = string.Format("{0:D2}:{1:D2}",minutes, seconds);
        
    }

    private void OnStateChanged(object sender, System.EventArgs e) {
        if(GameManager.Instance.IsGameRunning()) {
            gameObject.SetActive(true);
        }
        else {
            gameObject.SetActive(false);
        }
    }
}
