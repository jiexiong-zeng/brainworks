using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool IsCorrect = false;
    public QuizManager quizManager;
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
}
