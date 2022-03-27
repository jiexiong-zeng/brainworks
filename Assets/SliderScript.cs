using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] public Slider MySlider;

    public QuizManager quizManager;

    private string msg;

    public void setMsg(string msg)
    {
        this.msg = msg;
    }

    public void ConfirmSelection()
    {
        Debug.Log("Response collected.");
        quizManager.setScoringSystemValue(this.msg, (int)MySlider.value);
        quizManager.GoNext();
    }

    public void SetSliderVolume()
    {
        quizManager.ChangeAudioVolume(MySlider.value);
    }

}
