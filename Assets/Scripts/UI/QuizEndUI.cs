using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizEndUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI answeredText;
    [SerializeField] private TextMeshProUGUI gameTimeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameManager instance = GameManager.Instance;
        if (instance.isGameOver())
        {
            answeredText.text = instance.GetCorrectAnswersCount().ToString();
            gameTimeText.text = instance.GetGameTime().ToString();
        }
    }
}
