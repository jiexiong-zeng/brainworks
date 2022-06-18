using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCenter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RectTransform transform = this.GetComponent<RectTransform>();
        transform.anchoredPosition = new Vector2(-transform.rect.width/2, transform.anchoredPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
