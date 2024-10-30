using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI countDownText;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnStateChanged += OnStateChanged;
        gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        countDownText.text = Mathf.Ceil(GameManager.Instance.GetCountdownTimer()).ToString();
        
    }

    private void OnStateChanged(object sender, System.EventArgs e) {
        if(GameManager.Instance.IsCountDownRunning()) {
            gameObject.SetActive(true);
        }
        else {
            gameObject.SetActive(false);
        }
    }
}
