using UnityEngine.SceneManagement;
public enum LevelId
{
    MainMenu = 0,
    Game = 1
}

public static class LevelLoader
{
    public static void LoadLevel(LevelId id)
    {
        SceneManager.LoadScene((int)id);
    }
}
