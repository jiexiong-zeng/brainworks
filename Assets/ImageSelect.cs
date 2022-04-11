using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSelect : MonoBehaviour
{
    private string[] info;
    private int selector;
    public bool groupEnable = false;
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private GameObject imageObject;
    private Image image;
    [SerializeField] private GameObject[] toBeEnabled = new GameObject[8];
    [SerializeField] private Sprite[] imageList = new Sprite[8];
    [SerializeField] private GameObject[] groupA;
    [SerializeField] private GameObject[] groupB;



    void OnEnable()
    {
        info = quizManager.getGenderAndRace();
        string gender = info[0];
        Debug.Log("gender: " + gender);
        string race = info[1];
        Debug.Log("race: " + race);
        selector = findCase(gender, race);
        Debug.Log(selector);

        if (imageObject != null)
        {
            image = imageObject.GetComponent<Image>();
            SetImage();
        }
        else
        {
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

    public void SetImage()
    {
        image.sprite = imageList[selector - 1];
    }

}
