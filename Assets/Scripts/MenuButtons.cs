using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButtonsScript : MonoBehaviour
{
    public void OnPlayClick() {
        SceneLoader.Load(SceneLoader.Scene.QuizScene);
    }

    public void OnInfoClick() {
        Debug.Log("clicked info!");
    }

    public void OnLearnClick() {
        SceneLoader.Load(SceneLoader.Scene.ExploreScene);
    }

    public void onBackMainMenu() {
        SceneLoader.Load(SceneLoader.Scene.MenuScene);
    }
}
