using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public Toggle fullscrenToggle, vsyncToggle;

    public ResItem[] resolution;
    private int selectedResolution;
    public Text resolutionLabel;

    public AudioMixer theMixer;
    public Slider masterSlider, musicSlider, sfxSlider;
    public Text masterLabel, musicLabel, sfxLabel;

    void Start()
    {
        fullscrenToggle.isOn = Screen.fullScreen;
        if(QualitySettings.vSyncCount == 0)
        {
            vsyncToggle.isOn = false;
        }
        else
        {
            vsyncToggle.isOn = true;
        }
        //Search for resolution in list
        bool foundRes = false;
        for(int i = 0; i < resolution.Length; i++)
        {
            if( Screen.width == resolution[i].horizontal && Screen.height == resolution[i].vertical)
            {
                foundRes = true;
                selectedResolution = i;
                UpdateLabel();
            }
        }

        if (!foundRes)
        {
            resolutionLabel.text = Screen.width.ToString() + " X " + Screen.height.ToString();
        }

        if (PlayerPrefs.HasKey("Master"))
        {
            theMixer.SetFloat("Master", PlayerPrefs.GetFloat("Master"));
            masterSlider.value = PlayerPrefs.GetFloat("Master");
            
        }

        if (PlayerPrefs.HasKey("Music"))
        {
            theMixer.SetFloat("Music", PlayerPrefs.GetFloat("Music"));
            musicSlider.value = PlayerPrefs.GetFloat("Music");
            
        }

        if (PlayerPrefs.HasKey("SFX"))
        {
            theMixer.SetFloat("SFX", PlayerPrefs.GetFloat("SFX"));
            sfxSlider.value = PlayerPrefs.GetFloat("SFX");
            
        }

        masterLabel.text = (masterSlider.value + 80).ToString();
        musicLabel.text = (musicSlider.value + 80).ToString();
        sfxLabel.text = (sfxSlider.value + 80).ToString();

    }

    
    void Update()
    {
        
    }


    public void ResLeft()
    {
        selectedResolution--;
        if (selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        UpdateLabel();
    }

    public void ResRight()
    {
        selectedResolution++;
        if(selectedResolution > resolution.Length-1)
        {
            selectedResolution = resolution.Length -1;
        }
        UpdateLabel();
    }

    public void UpdateLabel()
    {
        resolutionLabel.text = resolution[selectedResolution].horizontal.ToString() + " X " + resolution[selectedResolution].vertical.ToString();
    }

    public void ApllyGraphics()
    {
      //  Screen.fullScreen = fullscrenToggle.isOn;
        if (fullscrenToggle.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
        // set resolution
        Screen.SetResolution(resolution[selectedResolution].horizontal, resolution[selectedResolution].vertical, fullscrenToggle.isOn);

    }

    public void SetMasterVol()
    {
        masterLabel.text = (masterSlider.value +80).ToString();
        theMixer.SetFloat("Master",masterSlider.value);
        PlayerPrefs.SetFloat("Master", masterSlider.value);
    }
    public void SetMusicVol()
    {
        musicLabel.text = (musicSlider.value + 80).ToString();
        theMixer.SetFloat("Music",musicSlider.value);
        PlayerPrefs.SetFloat("Music", musicSlider.value);
    }
    public void SetSfxVol()
    {
        sfxLabel.text = (sfxSlider.value + 80).ToString();
        theMixer.SetFloat("SFX",sfxSlider.value);
        PlayerPrefs.SetFloat("SFX", sfxSlider.value);
    }

}


[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}
