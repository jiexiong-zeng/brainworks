using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class ExportScores : MonoBehaviour
{
    [HideInInspector]
    public string filePath;
    StreamWriter streamWriter;
    
    // google form url taken from <form action="...">
    private string BASE_PATH = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSeU_qhg8rcRtDKJOv461caegteNUCh55-70jxSuzSHen-3-rQ/formResponse";
    // form fields taken from inspect element in google form <input name="entry.xxxxx" ... >
    IEnumerator Post(
        int playerId,
        int scenarioId,
        string age,
        string gender,
        string ethnicity,
        int rtf,
        double oucValue,
        int adrValue,
        string rsnValue,
        string walletQuestion,
        int rsc) {
        Debug.Log(oucValue.ToString());
        WWWForm form = new WWWForm();
        form.AddField("entry.635881576", playerId);
        form.AddField("entry.2017042329", scenarioId);
        form.AddField("entry.1433265299", age);
        form.AddField("entry.902942899", gender);
        form.AddField("entry.1178163597", ethnicity);
        form.AddField("entry.1015507325", rtf.ToString());
        form.AddField("entry.420657681", oucValue.ToString());
        form.AddField("entry.834619011", adrValue.ToString());
        form.AddField("entry.1841700359", rsnValue);
        form.AddField("entry.1258453114", walletQuestion);
        form.AddField("entry.2005283702", rsc.ToString());
        byte[] rawData = form.data;
        UnityWebRequest wwwRequest = UnityWebRequest.Post(BASE_PATH, form);
        yield return wwwRequest.SendWebRequest();
    }

    public void ExportToCSV(ScoringSystem scoringSystem) {
        if (!File.Exists(filePath)) {
            streamWriter = new StreamWriter(filePath, true);
            streamWriter.WriteLine("Time,Resistance to framing,Under/overconfidence,Applying Decision Rules,Recognizing social norms,Wallet Question,Resistance to sunk cost");
        }
        else {
            streamWriter = new StreamWriter(filePath, true);
        }
        streamWriter.WriteLine(
        System.DateTime.Now + "," +
        scoringSystem.playerID + "," +
        scoringSystem.ScenarioID + "," +
        scoringSystem.getRtf() + "," +
        scoringSystem.oucValue + "," + 
        scoringSystem.adrValue + "/" + 100 + "," +
        scoringSystem.rsnValue + "," +
        scoringSystem.riskPerceptionValue + "," +
        scoringSystem.getRsc());
        streamWriter.Flush();
        streamWriter.Close();

        StartCoroutine(Post(scoringSystem.playerID, scoringSystem.ScenarioID, scoringSystem.agString, scoringSystem.gender, scoringSystem.ethnicity, scoringSystem.getRtf(), scoringSystem.oucValue, scoringSystem.adrValue, scoringSystem.rsnValue, scoringSystem.riskPerceptionValue, scoringSystem.getRsc()));
    }
}
