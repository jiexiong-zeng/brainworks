using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageTypes : MonoBehaviour
{
    public AudioSource audio;
    public QuizManager quizManager;

    public void ChooseLanguage()
    {
        quizManager.SetAndPlayAudio(audio);
        quizManager.GoNext();
    }
}
