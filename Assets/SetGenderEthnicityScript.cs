using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGenderEthnicityScript : MonoBehaviour
{


    public QuizManager quizmanager;
    // Start is called before the first frame update
    public void SetMale()
    {
        quizmanager.gender = "male";
    }
    public void SetFemale()
    {
        quizmanager.gender = "female";
    }
    void SetCaucasian()
    {
        quizmanager.race = "caucasian";
    }
    void SetIndian()
    {
        quizmanager.race = "indian";
    }
    void SetMalay()
    {
        quizmanager.race = "malay";
    }
    void SetChinese()
    {
        quizmanager.race = "chinese";
    }

}
