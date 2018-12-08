
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnFlashOn : MonoBehaviour
{
    //public GrabNHoldR checkItem;
    public GameObject flashlight;
    public GameObject spotlight;

    public Light lighter;
    private bool lightSwitch;




    // Use this for initialization
    void Start()
    {
 
        lightSwitch = false;
        lighter.enabled = false;
        Debug.Log("startoff");

    }


    void Update()
    {
       
        if (GameObject.Find("RightHandAnchor").GetComponent<GrabNHoldR>().checkBool == true)
        {
            FlashToggle();
        }

      
    }


    public void FlashToggle( )
    {
        if (OVRInput.GetDown(OVRInput.Button.One) == true) {
            if (lighter.enabled == true)
            {
                lighter.enabled = false;
                Debug.Log("light is now false");
            }
            else if (lighter.enabled == false)
            {
                lighter.enabled = true;
                Debug.Log("light is now true");
            }
        }
            
    }
    



}
