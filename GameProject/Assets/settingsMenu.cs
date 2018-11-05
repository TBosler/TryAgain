using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class settingsMenu : MonoBehaviour {

    public AudioMixer audiomixer;

	// Use this for initialization
	public void setVolume(float volume)
    {
        audiomixer.SetFloat("MasterVolume", volume);
    }
}
