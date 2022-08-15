using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        optionsMenu.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ArenaMenu()
    {
        SceneManager.LoadScene("ArenaMenu");
    }

    public void PanelOptions()
    {
        optionsMenu.SetActive(true);
    }

    public void ClosePainelOptions()
    {
        optionsMenu.SetActive(false );
    }
    


    public void Exit()
    {
        Application.Quit();
    }


}
