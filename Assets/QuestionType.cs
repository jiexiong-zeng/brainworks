using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class QuestionType
{

    public string Type;

    //For "TF", value 0 or 1
    public int CorrectOption;

    [Multiline]
    public string Question;
    //public string[] Answers;
    public GameObject[] Options;


    public void SetAnswers()
    {
        if (Type == "TF")
        {
            if (CorrectOption == 0)
            {
                //False is correct
                this.Options[0].GetComponent<AnswerScript>().IsCorrect = true;
            }
            else
            {
                //True is correct
                this.Options[1].GetComponent<AnswerScript>().IsCorrect = true;
            }
        }

        else if (Type == "MRQ")
        {
            for (int i = 0; i < this.Options.Length; i++)
            {
                if (CorrectOption == i + 1)
                {
                    this.Options[i].GetComponent<AnswerScript>().IsCorrect = true;
                }
            }
        }

        else if (Type == "Slider")
        {
            //Future functionality
        }

        else if (Type == "InputField")
        {
            //Future functionality
        }


    }

}
