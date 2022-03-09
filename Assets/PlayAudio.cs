using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] voiceOvers;
    [SerializeField] private QuizManager quizManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayVoice()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(voiceOvers[quizManager.getCurrentPanelIndex()]);
    }


}
