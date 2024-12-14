using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RemainingQuestionsUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI remainingQuestionsText;

    void Start()
    {
        GameManager.Instance.OnStateChanged += OnStateChanged;
        GameManager.Instance.OnBoneChanged += OnBoneChanged;
        gameObject.SetActive(false);
        
    }

    private void OnBoneChanged(object sender, System.EventArgs e)
    {
        remainingQuestionsText.text = string.Format("{0}/{1}", GameManager.Instance.GetCurrentQuestionIndex(), GameManager.Instance.GetTotalQuestions());
    }

    private void OnStateChanged(object sender, System.EventArgs e)
    {
         gameObject.SetActive(GameManager.Instance.IsGameRunning());
    }
}
