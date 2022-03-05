using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] public Slider MySlider;

    public QuizManager quizManager;

    public void ConfirmSelection()
    {
        Debug.Log("Response collected.");
        quizManager.SetSliderValue((int)MySlider.value);
        quizManager.Correct();
    }

    public void SetSliderVolume()
    {
        quizManager.ChangeAudioVolume(MySlider.value);
    }

}
