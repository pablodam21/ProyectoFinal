using System.Collections;
using static System.Math;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    private float volume;
    
    public Slider slider;
    
    public AudioSource audioSource;
    // Start is called before the first frame update

    public void OnVolumeChanged()
    {
        volume = slider.value;
        volume = (float) System.Math.Round(volume,1);
        audioSource.volume = volume;
        
    }
}
