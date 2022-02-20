using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ReadInputScript : MonoBehaviour
{
    public int val = -1;
    public QuizManager quizManager;

    public void ReadStringInput(string s)
    {
        if (int.TryParse(s, out val))
        {
            quizManager.SetInputFieldValue(val);
            quizManager.Correct();
        }

        else
        {
            Debug.Log("Non-integer value detected.");
        }
        
    }
}
