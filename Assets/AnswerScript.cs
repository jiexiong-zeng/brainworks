using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool IsCorrect = false;
    public QuizManager quizManager;

    public void Answer()
    {
        if(IsCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.Correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizManager.Wrong();
        }
    }
}
