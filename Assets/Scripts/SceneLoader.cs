using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public enum Scene
    {
        MenuScene,
        QuizScene,
        ExploreScene
    }

    public static void Load(Scene targetScene)
    {
        SceneManager.LoadScene(targetScene.ToString());
    }
}
