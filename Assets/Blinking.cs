using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Blinking : MonoBehaviour
{
    // the image you want to fade, assign in inspector
    private Image img;

    public void Start()
    {

        img = GetComponent<Image>();
        // fades the image out when you click
        StartCoroutine(FadeImage(true));
    }

    public void FixedUpdate()
    {
        Debug.Log(img.color.a);
        if (img.color.a <= 0.01)
        {
            StartCoroutine(FadeImage(false));
        }
        if (img.color.a >= 0.99)
        {
            StartCoroutine(FadeImage(true));
        }
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= 2*Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += 2*Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}

