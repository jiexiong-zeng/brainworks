using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    [SerializeField] private string targetScene;
    [SerializeField] private GameObject nextSlide;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonChangeScene()
    {
        SceneManager.LoadScene(targetScene);
    }
    
    public void NextSlide()
    {
        nextSlide.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
