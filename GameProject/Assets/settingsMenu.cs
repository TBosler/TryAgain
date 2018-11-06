using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class settingsMenu : MonoBehaviour {

    public AudioMixer audiomixer;
    public TMPro.TMP_Dropdown res;
    Resolution[] resolutions;
    private bool fullscreen = true;

    private void Start()
    {
        Screen.fullScreen = fullscreen;
        resolutions = Screen.resolutions;
        res.ClearOptions();

        List<string> options = new List<string>();

        int currentRes = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentRes = i;
            }

        }

        res.AddOptions(options);
        res.value = currentRes;
        res.RefreshShownValue();
    }

    public void setRes(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Use this for initialization
    public void setVolume(float volume)
    {
        audiomixer.SetFloat("MasterVolume", volume);
    }

    public void setQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void setFullscreen(bool full)
    {
        Screen.fullScreen = full;
       fullscreen = full;
    }
}

