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
    
    // google form url
    private string BASE_PATH = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSc6YcIeBmKvDry_neC666cBFb1L6JKEhtlFis8MMISckjw9UA/formResponse";
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
        form.AddField("entry.380980382", playerId);
        form.AddField("entry.1291519487", scenarioId);
        form.AddField("entry.375521994", age);
        form.AddField("entry.1392694819", gender);
        form.AddField("entry.1606668309", ethnicity);
        form.AddField("entry.1242502216", rtf.ToString());
        form.AddField("entry.1723200376", oucValue.ToString());
        form.AddField("entry.883043933", adrValue.ToString());
        form.AddField("entry.1304599494", rsnValue);
        form.AddField("entry.1654742979", walletQuestion);
        form.AddField("entry.1810348849", rsc.ToString());
        byte[] rawData = form.data;
        WWW www = new WWW(BASE_PATH, rawData);
        yield return www;
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
