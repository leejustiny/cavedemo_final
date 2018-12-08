using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenItem : MonoBehaviour { //should be on ground collider

    public GameObject originalItem1;
    public GameObject originalItem2;
    public bool RegenItems;
    public Transform spawnLocation1;
    public Transform spawnLocation2;
    private GameObject instantiatedObject;

    public GameObject pickaxe;
    public GameObject flashlight;



    // Use this for initialization
    void Start () {
        originalItem1 = GameObject.FindGameObjectWithTag("flashlight");
        originalItem2 = GameObject.FindGameObjectWithTag("Pickaxe");

   
        RegenItems = true;
    }

    void OnTriggerEnter(Collider item) //item is pickaxe or flashlight
    {
     

        if (item.gameObject.tag == ("Pickaxe"))  //if this item is pickaxe or flashlight
        {
            // Regenitem(item, itemComp); //gameobject.name
            if (RegenItems)
            {
                
                Destroy(originalItem2);
                instantiatedObject = Instantiate(pickaxe, spawnLocation2.position, spawnLocation2.rotation);
        //        instantiatedObject.transform.position = spawnLocation2;
               
            //    originalItem2 = instantiatedObject;
                RegenItems = false;
             //   return originalItem2;
            }
        }

        if (item.gameObject.tag == ("flashlight"))  //if this item is pickaxe or flashlight
        {
            // Regenitem(item, itemComp); //gameobject.name
            if (RegenItems)
            {
                Destroy(originalItem1);
                instantiatedObject = Instantiate(flashlight, spawnLocation1.position, spawnLocation1.rotation);
               // instantiatedObject.transform.position = spawnLocation1;
               // originalItem1 = instantiatedObject;
                RegenItems = false;
           //     return originalItem1;
            }
        }

        //Destroy(item.gameObject);
        //item.gameObject = insta
     //   RegenItems = true;
    //    return instantiatedObject;

    }


    // Update is called once per frame
    void Update () {
        originalItem1 = GameObject.FindGameObjectWithTag("flashlight");
        originalItem2 = GameObject.FindGameObjectWithTag("Pickaxe");

        if (originalItem1.transform != spawnLocation1)
        {
            RegenItems = true;
        }
        if (originalItem2.transform != spawnLocation2)
        {
            RegenItems = true;
        }

    }


}
