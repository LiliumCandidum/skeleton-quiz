using System;
using TMPro;
using UnityEngine;

public class QuizEndUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI answeredText;
    [SerializeField] private TextMeshProUGUI gameTimeText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGameOver += OnGameOver;
        gameObject.SetActive(false);
    }

    private void OnGameOver(object sender, System.EventArgs e)
    {
        GameManager instance = GameManager.Instance;
        if (instance.isGameOver())
        {
            gameObject.SetActive(true);
            float time = GameManager.Instance.GetGameTime();
            Debug.Log(time);
            Debug.Log(TimeSpan.FromSeconds(time));
            answeredText.text = "You answered " + instance.GetCorrectAnswersCount().ToString() + " correctly";
            gameTimeText.text = "Time: " + TimeSpan.FromSeconds(time).ToString(@"mm\:ss");
        }
    }
}
