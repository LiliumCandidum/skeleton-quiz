using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnswerClickListener : MonoBehaviour, IPointerClickHandler
{
    Color bgColor;

    void Start()
    {
        bgColor = new Color();
        ColorUtility.TryParseHtmlString("#FFB04F", out bgColor);

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
        background.color = bgColor;
    }

    private void OnStateChanged(object sender, System.EventArgs e)
    {
        gameObject.SetActive(GameManager.Instance.IsGameRunning());
    }
}
