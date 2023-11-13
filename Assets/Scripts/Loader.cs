using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        LoadingScene,
        Level_1,
        Level_2
    }

    private static Scene targetScene;

    public static void LoaderCallBack()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }

    public static void Load(Scene scene)
    {
        targetScene = scene;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());

    }
}
