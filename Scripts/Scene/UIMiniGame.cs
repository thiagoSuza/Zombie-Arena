using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMiniGame : MonoBehaviour
{
    public GameObject panelPauser;
    public GameObject panelOptions;
    public GameObject panelGameOver;
    private int x = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        panelPauser.SetActive(false);
        panelOptions.SetActive(false);
        panelGameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
        ActivePanelPauser();
    }

    public void Pause()
    {

        if (Input.GetKeyDown(KeyCode.P) && (x % 2) != 0)
        {
            Debug.Log("Apertei p");
            Time.timeScale = 0f;


            

        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            x++;
        }

        if (Input.GetKeyDown(KeyCode.P) && (x % 2) == 0)
        {
            Debug.Log("APertei L");
            Time.timeScale = 1f;

            

        }

    }

    public void ActivePanelPauser()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelPauser.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void MenuArena()
    {
        SceneManager.LoadScene("ArenaMenu");
        Time.timeScale = 1f;
    }

    public void ResumeGame()
    {
        panelPauser.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OptionsOn()
    {
        panelOptions.SetActive(true);
    }

    public void OptionsOff()
    {
        panelOptions.SetActive(false);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
