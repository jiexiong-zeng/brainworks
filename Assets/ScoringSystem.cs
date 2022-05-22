using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoringSystem : MonoBehaviour
{
    public int tester;

    public int ScenarioID;

    public int playerID;
    //Age group
    private int ag;

    //Gender
    private int g;

    //Ethnicity
    private int e;

    //Resistance to framing
    private int rtf1, rtf2;

    //Under/overconfidence
    private bool uoc1, uoc2;
    private int uocv1, uocv2;

    //Applying Decision Rules
    private bool flag1 = false;
    private bool flag2 = false;

    private bool adr1, adr2;

    //Recognizing social norms
    private bool rsn;

    private int rsnVal;

    //Consistency in Risk Perception
    private int v1, v2;

    //Resistance to sunk cost
    private int rsc1, rsc2;

    //Final Score variables
    public int adrValue;
    public double oucValue;
    public string rsnValue;
    public string riskPerceptionValue;
    public string pathIndependence;
    public String gender;
    public String agString;
    public String ethnicity;

    public void setValue(string s, int val)
    {
        if (s == "tester")
        {
            this.tester = val;
        }

        if (s == "scenario")
        {
            this.ScenarioID = val;
        }

        if (s == "pid")
        {
            this.playerID = val;
        }
        
        if (s == "ag")
        {
            this.ag = val;
        }
        if (s == "g")
        {
            this.g = val;
        }
        if (s == "e")
        {
            this.e = val;
        }
        if (s == "rtf1")
        {
            this.rtf1 = val;
        }
        else if (s == "rtf2")
        {
            this.rtf2 = val;
        }
        else if (s == "uocv1")
        {
            this.uocv1 = val;
        }
        else if (s == "uocv2")
        {
            this.uocv2 = val;
        }
        else if (s == "rsnVal")
        {
            this.rsnVal = val;
        }
        else if (s == "v1")
        {
            this.v1 = val;
        }
        else if (s == "v2")
        {
            this.v2 = val;
        }
        else if (s == "rsc1")
        {
            this.rsc1 = val;
        } else if (s == "rsc2")
        {
            this.rsc2 = val;
        }
    }

    public void setValue(string s, bool tf)
    {
        if (s == "uoc1")
        {
            this.uoc1 = tf;
        }
        else if (s == "uoc2")
        {
            this.uoc2 = tf;
        }
        else if (s == "adr1")
        {
            if (!flag1)
            {
                flag1 = true;
                this.adr1 = tf;
            }
            
        }
        else if (s == "adr2")
        {
            if (!flag2)
            {
                flag2 = true;
                this.adr2 = tf;
            }     
        }
        else if (s == "rsn")
        {
            this.rsn = tf;
        }
    }

    public string getAnswers()
    {
        Debug.Log(this.ag);
        Debug.Log(this.g);
        Debug.Log(this.e);

        switch (this.ag)
        {
            case 1:
                agString = "Under 60";
                break;
            case 2:
                agString = "60-65";
                break;
            case 3:
                agString = "65-70";
                break;
            case 4:
                agString = "70-75";
                break;
            case 5:
                agString = "75-80";
                break;
            case 6:
                agString = "Over 80";
                break;
            default:
                agString = "NONE";
                break;
        }

        switch (this.g)
        {
            case 1:
                gender = "Female";
                break;
            case 2:
                gender = "Male";
                break;
            default:
                gender = "NONE";
                break;
        }

        switch (this.e)
        {
            case 1:
                ethnicity = "Caucasian";
                break;
            case 2:
                ethnicity = "Indian";
                break;
            case 3:
                ethnicity = "Malay";
                break;
            case 4:
                ethnicity = "Chinese";
                break;
            default:
                ethnicity = "NONE";
                break;
        }

        adrValue = 0;
        if (this.adr1)
        {
            adrValue += 50;
        }
        if (this.adr2)
        {
            adrValue += 50;
        }

        double oucV = 0;
        if (uoc1)
        {
            oucV += 0.5;
        }
        if (uoc2)
        {
            oucV += 0.5;
        }

        double d1 = uocv1 * 10 + 40;
        double d2 = uocv2 * 10 + 40;
        oucValue = 1 - Math.Abs(((d1 + d2) / 200) - oucV);

        rsnValue = this.rsn ? "Correct" : "Incorrect";

        riskPerceptionValue = v1 < v2 ? "Correct" : "Incorrect";

        pathIndependence = rsc1 == rsc2 ? "Correct" : "Incorrect";

        return //"TESTER:" + tester + "\n" + 
               "Scenario ID: " + ScenarioID + "\n" +
               "Player ID: " + playerID + "\n" +
               "Age Group: " + agString + "\n" +
               "Gender: " + gender + "\n" +
               "Ethnicity: " + ethnicity + "\n" +
               "Resistance to framing: " + getRtf() + "\n" +
               "Underconfidence / Overconfidence: " + oucValue + "\n" +
               "Applying decision rules: " + adrValue + "/" + 100 + "\n" +
               "Recognizing social norms: " + rsnValue + "\n" +

               "(SCENARIO 2 ONLY) Out of 100 people, how many will: " + rsnVal + "\n" +

               "Consistency in Risk Perception: " + riskPerceptionValue + "\n" +
               "Resistance to sunk cost: " + getRsc() + "\n" +
               "Path independence:" + pathIndependence;
    }

    public int getRtf() {
        return Math.Abs(rtf1 - rtf2);
    }

    public int getRsc() {
        return Math.Abs(rsc1 - rsc2);
    }
}
