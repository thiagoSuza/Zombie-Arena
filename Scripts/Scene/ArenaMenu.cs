using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaMenu : MonoBehaviour
{

    

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void Arena()
    {
        SceneManager.LoadScene("Arena");
    }

    public void Cave()
    {
        SceneManager.LoadScene("Cave");
    }

    public void House()
    {
        SceneManager.LoadScene("House");
    }

    public void Park()
    {
        SceneManager.LoadScene("Park");
    }

    public void Woods()
    {
        SceneManager.LoadScene("Woods");
    }

    public void MiniGame()
    {
        SceneManager.LoadScene("MiniGameMenu");
    }

}








