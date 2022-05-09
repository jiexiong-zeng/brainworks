using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnswerScript : MonoBehaviour
{
    public int optionNo;
    public bool IsCorrect = false;
    public QuizManager quizManager;
    public TextMeshProUGUI QuestionText;
    private string msg = "NONE";

    public void setMsg(string msg)
    {
        this.msg = msg;
    }

    public void Answer()
    {
        quizManager.setScoringSystemValue(this.msg, IsCorrect);
        quizManager.GoNext();
    }

    public void AnswerWithNumber()
    {
        quizManager.setScoringSystemValue(this.msg, optionNo);
        quizManager.GoNext();
    }

    public void setScenario(int i)
    {
        quizManager.setScoringSystemValue("scenario", i);
        quizManager.GoNext();
    }

    public void WrongAnswerTryAgain(string s)
    {
        quizManager.setScoringSystemValue(this.msg, IsCorrect);
        QuestionText.SetText(s);
    }
    
    public void SetGender(string gender)
    {
        quizManager.gender = gender;
    }

    public void SetEthnicity(string ethnicity)
    {
        quizManager.race = ethnicity;
    }
}
