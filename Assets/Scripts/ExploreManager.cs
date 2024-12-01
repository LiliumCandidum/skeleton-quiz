using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExploreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;

    public static ExploreManager Instance { get; private set; }

    private Renderer prevGameObjectRenderer;
    private Color selectedColor;

    public void OnBoneClick(Renderer currGameObjectRenderer, Transform parentTransform)
    {
        if (prevGameObjectRenderer != null)
        {
            prevGameObjectRenderer.material.color = Color.white;
        }

        if (!GameObject.ReferenceEquals(prevGameObjectRenderer, currGameObjectRenderer))
        {
            currGameObjectRenderer.material.color = selectedColor;

            if (parentTransform != null)
            {
                String[] splitted = parentTransform.name.Split('_');
                nameText.text = splitted[splitted.Length - 1];
            } else
            {
                nameText.text = "Unknown bone";
            }

            prevGameObjectRenderer = currGameObjectRenderer;
        } else
        {
            prevGameObjectRenderer = null;
            nameText.text = null;
        }
    }

    void Awake()
    {
        Instance = this;

        selectedColor = new Color();
        ColorUtility.TryParseHtmlString("#BF2100", out selectedColor);
    }
}
