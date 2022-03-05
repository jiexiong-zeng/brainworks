using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public GameObject volumeButton;
    [SerializeField] public Slider volumeSlider;
    public AudioSource audioSource;

    public List<GameObject> languageButtons;

    public List<AudioSource> allSounds;

    public void setVolume()
    {
        audioSource.volume = volumeSlider.value;
    }
    



}
