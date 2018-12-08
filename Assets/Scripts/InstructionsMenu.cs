using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InstructionsMenu : MonoBehaviour
{
    public GameObject Instructions;
    private bool menu = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (OVRInput.Get(OVRInput.Button.Three))
        {
                Instructions.SetActive(!menu);
            menu = !menu;
        }
        if (OVRInput.Get(OVRInput.Button.Four))
        {
            SceneManager.LoadScene(0);
        }
        if (OVRInput.Get(OVRInput.Button.Start))
        {
            //Quit
            Application.Quit();
        }
    }
}