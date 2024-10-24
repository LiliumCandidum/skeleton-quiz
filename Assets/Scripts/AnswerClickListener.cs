using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnswerClickListener : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] GameManager gameManager;
    // Start is called before the first frame update

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked Answer");
        if (gameManager != null)
        {
            gameManager.OnAnswerClick(gameObject);
        }
    }
}
