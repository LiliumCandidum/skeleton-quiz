using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RemainingQuestionsUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI remainingQuestionsText;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnStateChanged += OnStateChanged;
        GameManager.Instance.OnBoneChanged += OnBoneChanged;
        gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnBoneChanged(object sender, System.EventArgs e) {
        remainingQuestionsText.text = string.Format("{0}/{1}", GameManager.Instance.GetCurrentQuestionIndex(), GameManager.Instance.GetTotalQuestions());
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
