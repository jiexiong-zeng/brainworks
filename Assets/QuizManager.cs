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
    public GameObject GOPanel;

    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI ScoreText;

    public string gender;
    public string race;



    //Input field questions
    public int input1;

    private int CurrentQuestionIndex = 0;
    private int CurrentPanelIndex = 0;
    private int TotalQuestions = 0;

    //Audio
    public Slider volumeSlider;
    public AudioSource audio;
    [SerializeField] private PlayAudio playAudio;

    private ScoringSystem SS = new ScoringSystem();
    [SerializeField]
    private ExportScores exportScores;

    private void Start()
    {
        //initialise
        gender = "female";
        race = "malay";

    exportScores = gameObject.GetComponent<ExportScores>();
        exportScores.filePath = Application.dataPath + "/Scores.csv";
        //Debug.Log(Application.dataPath);
        TotalQuestions = QnA.Count;
        GOPanel.SetActive(false);
        for (int i = 0; i < Panels.Length; i++)
        {
            Panels[i].SetActive(false);
        }
        QuestionPanel.SetActive(true);
        AudioOverlayPanel.SetActive(true);
        Panels[CurrentPanelIndex].SetActive(true);
        GenerateQuestion();
        SetAndPlayAudio(audio);
        playAudio.PlayVoice();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        for (int i = 0; i < Panels.Length; i++)
        {
            Panels[i].SetActive(false);
        }
        QuestionPanel.SetActive(true);
        GOPanel.SetActive(true);
        QuestionText.SetText("FINISHED");
        ScoreText.SetText(SS.getAnswers());
        exportScores.ExportToCSV(SS);
        //Panels[Panels.Length - 1].SetActive(true);

    }

    public void GoNext()
    {
        GenerateQuestion();
        
        Panels[CurrentPanelIndex].SetActive(false);
        CurrentPanelIndex += 1;
        if (CurrentPanelIndex < QnA.Count)
        {
            Panels[CurrentPanelIndex].SetActive(true);
        }
        playAudio.PlayVoice();

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

    public void setScoringSystemValue(string msg, int val)
    {
        if (msg != "NONE")
        {
            SS.setValue(msg, val);
        }
    }

    public void setScoringSystemValue(string msg, bool tf)
    {
        if (msg != "NONE")
        {
            SS.setValue(msg, tf);
        }
    }
}
