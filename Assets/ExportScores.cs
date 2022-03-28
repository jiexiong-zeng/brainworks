using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ExportScores : MonoBehaviour
{
    public string filePath;
    StreamWriter streamWriter;
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
        scoringSystem.getRtf() + "," +
        scoringSystem.oucValue + "," + 
        scoringSystem.adrValue + "/" + 100 + "," +
        scoringSystem.rsnValue + "," +
        scoringSystem.walletQuestion + "," +
        scoringSystem.getRsc());
        streamWriter.Flush();
        streamWriter.Close();
    }
}
