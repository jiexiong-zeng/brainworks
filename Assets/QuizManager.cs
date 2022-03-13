using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QuestionType> QnA;
    private QuestionType CurrentQuestion;

    public GameObject QuestionPanel;
    public GameObject AudioOverlayPanel;
    public GameObject[] Panels;

    public TextMeshProUGUI QuestionText;
    public Text ScoreText;

    public string gender = "male";
    public string race = "malay";


    //Slider variables
    public int SliderValue;

    //Input field questions
    public int input1;

    private int CurrentQuestionIndex = 0;
    private int CurrentPanelIndex = 0;
    private int TotalQuestions = 0;
    public int Score;

    //Audio
    public Slider volumeSlider;
    public AudioSource audio;

    
    private void Start()
    {
        TotalQuestions = QnA.Count;
        for (int i = 0; i < Panels.Length; i++)
        {
            Panels[i].SetActive(false);
        }
        QuestionPanel.SetActive(true);
        AudioOverlayPanel.SetActive(true);
        Panels[CurrentPanelIndex].SetActive(true);
        GenerateQuestion();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        //QuizPanel.SetActive(false);
        //GOPanel.SetActive(true);
        QuestionPanel.SetActive(false);
        for (int i = 0; i < Panels.Length; i++)
        {
            Panels[i].SetActive(false);
        }
        Panels[Panels.Length - 1].SetActive(true);
        ScoreText.text = "Questions Answered:\n" + Score + "/" + TotalQuestions;
    }

    public void Correct()
    {
        Score += 1;
        GenerateQuestion();
        Panels[CurrentPanelIndex].SetActive(false);
        CurrentPanelIndex += 1;
        Panels[CurrentPanelIndex].SetActive(true);
    }

    public void Wrong()
    {
        Score += 1;
        GenerateQuestion();
        Panels[CurrentPanelIndex].SetActive(false);
        CurrentPanelIndex += 1;
        Panels[CurrentPanelIndex].SetActive(true);
    }

    /*
    void SetAnswers()
    {
        for (int i = 0; i < Options.Length; i++)
        {
            Options[i].GetComponent<AnswerScript>().IsCorrect = false;
            Options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[CurrentQuestionIndex].Answers[i];

            if(QnA[CurrentQuestionIndex].CorrectAnswerIndex == i + 1)
            {
                Options[i].GetComponent<AnswerScript>().IsCorrect = true;
            }
        }

    }
    */
    public void SetSliderValue(int sv)
    {
        this.SliderValue = sv;
    }

    public void SetInputFieldValue(int ifv)
    {
        this.input1 = ifv;
    }

    void GenerateQuestion()
    {
        if(CurrentQuestionIndex < QnA.Count)
        {
            CurrentQuestion = QnA[CurrentQuestionIndex];
            QuestionText.SetText(CurrentQuestion.Question);
            CurrentQuestion.SetAnswers();
            CurrentQuestionIndex += 1;
        }
        else
        {
            Debug.Log("Out of Questions.");
            GameOver();
        }
        
    }

    public void SetAndPlayAudio(AudioSource a)
    {
        this.audio = a;
        this.audio.Play();
    }

    public void ChangeAudioVolume(float sliderValue)
    {
        this.audio.volume = sliderValue;
    }

    public int getCurrentPanelIndex()
    {
        return CurrentPanelIndex;
    }

    public string[] getGenderAndRace()
    {
        return new string[] { gender, race };
    }

}
