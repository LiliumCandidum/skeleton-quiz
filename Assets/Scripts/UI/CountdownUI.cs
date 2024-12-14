using TMPro;
using UnityEngine;

public class CountdownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countDownText;

    void Start()
    {
        GameManager.Instance.OnStateChanged += OnStateChanged;
    }

    void Update()
    {
        countDownText.text = Mathf.Ceil(GameManager.Instance.GetCountdownTimer()).ToString();
    }

    private void OnStateChanged(object sender, System.EventArgs e)
    {
        gameObject.SetActive(GameManager.Instance.IsCountDownRunning());
    }
}
