using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSelect : MonoBehaviour
{
    private string[] info;
    private int selector;
    public bool groupEnable = false;
    [SerializeField] private QuizManager quizManager;

    [SerializeField] private GameObject[] toBeEnabled = new GameObject[8];
    [SerializeField] private GameObject[] groupA;
    [SerializeField] private GameObject[] groupB;



    void OnEnable()
    {
        info = quizManager.getGenderAndRace();
        string race = info[0];
        string gender = info[1];
        selector = findCase(race, gender);

        if (!groupEnable)
            toBeEnabled[selector - 1].SetActive(true);
        else
        {
            if (selector <= 4)
                EnableGroup(groupA);
            else
                EnableGroup(groupB);
        }
    }

    private int findCase(string gender, string race)
    {
        switch (gender)
        {
            case "male":
                switch (race)
                {
                    case "caucasian":
                        selector = 1;
                        break;
                    case "indian":
                        selector = 2;
                        break;
                    case "malay":
                        selector = 3;
                        break;
                    case "chinese":
                        selector = 4;
                        break;
                }
                break;
            case "female":
                switch (race)
                {
                    case "caucasian":
                        selector = 5;
                        break;
                    case "indian":
                        selector = 6;
                        break;
                    case "malay":
                        selector = 7;
                        break;
                    case "chinese":
                        selector = 8;
                        break;
                }
                break;
        }

        return selector;
    }

    private void EnableGroup(GameObject[] group)
    {
        foreach (GameObject gameObject in group)
        {
            gameObject.SetActive(true);
        }
    }

}
