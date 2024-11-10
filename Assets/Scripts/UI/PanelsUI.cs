using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnswerClickListener : MonoBehaviour, IPointerClickHandler
{

    // Start is called before the first frame update
    void Awake()
    {

    }

    void Start()
    {
        GameManager.Instance.OnStateChanged += OnStateChanged;
        GameManager.Instance.OnBoneChanged += OnBoneChanged;
        gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked Answer");
        Image background = gameObject.GetComponent<Image>();
        if (GameManager.Instance.OnAnswerClick(gameObject.GetComponentInChildren<TextMeshProUGUI>().text))
        {
            background.color = Color.green;
        }
        else
        {
            background.color = Color.red;
        }
    }

    private void OnBoneChanged(object sender, System.EventArgs e)
    {

        Image background = gameObject.GetComponent<Image>();
        background.color = new Color(1f, 1f, 1f, 1f);
    }

    private void OnStateChanged(object sender, System.EventArgs e)
    {

        if (GameManager.Instance.IsGameRunning())
        {
            Debug.Log("running");
            gameObject.SetActive(true);
        }
        else {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {

    }
}
