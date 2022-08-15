using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text score;
    public Text granades;
    public Text sentury;
    public Text oClokText;
    private int x = 1; 
    public GameObject panelPauser;
    public GameObject panelOptions;
    public GameObject panelGameOver;
    public Text hightScore;
    
    

    public int zumbiesKilled;

    private void Awake()
    {
       
        oClokText = GetComponent<Text>();
    }


    // Start is called before the first frame update
    void Start()
    {
        zumbiesKilled = 0;
        panelPauser.SetActive(false);
        panelOptions.SetActive(false); 
        panelGameOver.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        GranadaAndSenturyAcount();
        //SliderController();
        AcountScore();
        Pause();
        ActivePanelPauser();
        GameOverPanel();
    }
   


    public void GranadaAndSenturyAcount()
    {
        if(GameManager.instance.playerAlived == true)
        {
            granades.text = FindObjectOfType<ActionOfFire>().numberOfGranades.ToString();
            sentury.text = FindObjectOfType<ActionOfFire>().numberOfSentury.ToString();
        }
        
    }

    public void AcountScore()
    {
        score.text = ("Zombies Killed : " + zumbiesKilled).ToString();
    }

    public void Pause( ) 
    {
        
        if (Input.GetKeyDown(KeyCode.P) && (x % 2) != 0)
        {
            Debug.Log("Apertei p");
                Time.timeScale = 0f;
          
            
            Debug.Log(x);

        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            x++;
        }

        if (Input.GetKeyDown(KeyCode.P) && (x % 2) == 0)
        {
            Debug.Log("APertei L");
            Time.timeScale = 1f;
           
            Debug.Log(x);

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

    public void GameOverPanel()
    {
        if(GameManager.instance.playerAlived == false)
        {
            
            panelGameOver.SetActive(true);

        }

        

        if(zumbiesKilled> PlayerPrefs.GetInt("hightScoreZ"))
        {
            PlayerPrefs.SetInt("hightScoreZ",zumbiesKilled);
        }
        hightScore.text = " HIGHT SCORE : " + PlayerPrefs.GetInt("hightScoreZ");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
