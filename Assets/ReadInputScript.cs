using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class ReadInputScript : MonoBehaviour
{
    public int val = -1;
    [SerializeField] GameObject input;
    public QuizManager quizManager;
    private string msg = "NONE";

    public void setMsg(string msg)
    {
        this.msg = msg;
    }



    public void ReadStringInput()
    {
        string s = input.GetComponent<TMP_InputField>().text;
        if (int.TryParse(s, out val) && (0 <= this.val) && (this.val <= 100))
        {
            quizManager.setScoringSystemValue(this.msg, val);
            quizManager.GoNext();
        }

        else
        {
            Debug.Log("Invalid input detected.");
        }
        
    }

    public void ReadPlayerID(string s)
    {
        if (int.TryParse(s, out val))
        {
            quizManager.setScoringSystemValue(this.msg, val);
            quizManager.GoNext();
        }

        else
        {
            Debug.Log("Invalid input detected.");
        }
    }
}
