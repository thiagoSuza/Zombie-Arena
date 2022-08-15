using UnityEngine;
using UnityEngine.SceneManagement;


public class MiniGame : MonoBehaviour
{
    public void MenuArena()
    {
        SceneManager.LoadScene("ArenaMenu");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MiniGamePlay");
    }
}
