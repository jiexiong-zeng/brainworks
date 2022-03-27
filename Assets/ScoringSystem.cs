using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoringSystem : MonoBehaviour
{
    //Resistance to framing
    private int rtf1, rtf2;

    //Under/overconfidence
    private bool uoc1, uoc2;
    private int uocv1, uocv2;

    //Applying Decision Rules
    private bool adr1, adr2;

    //Recognizing social norms
    private bool rsn;

    //Forget Wallet Question (Currently no framework in place)
    private int v1, v2;

    //Resistance to sunk cost
    private int rsc1, rsc2;


    public void setValue(string s, int val)
    {   
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
            this.adr1 = tf;
        }
        else if (s == "adr2")
        {
            this.adr2 = tf;
        }
        else if (s == "rsn")
        {
            this.rsn = tf;
        }
    }


    public string getAnswers()
    {
        int adrValue = 0;
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
        double oucValue = 1 - Math.Abs(((d1 + d2) / 200) - oucV);

        string rsnValue = this.rsn ? "Correct" : "Wrong";

        string walletQuestion = v1 < v2 ? "Correct" : "Wrong";

        return "Resistance to framing: " + Math.Abs(rtf1 - rtf2) + "\n" +
               "Underconfidence / Overconfidence: " + oucValue + "\n" + 
               "Applying decision rules: " + adrValue + "/" + 100 + "\n" +
               "Recognizing social norms: " + rsnValue + "\n" +
               "Wallet Question: " + walletQuestion + "\n" +
               "Resistance to sunk cost: " + Math.Abs(rsc2 - rsc1);
    }
    

}
