using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public GameObject cave;
    public GameObject door;
    public Collider caveColl;
    public Collider doorColl;
    public Collider ringColl1;
    public Collider ringColl2;


    private void OnTriggerEnter(Collider diamond)
    {
        if (diamond.gameObject.tag == ("Diamond"))
        {
            OpenTheDoor();
        }
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {




    }

    public void OpenTheDoor()
    {
        caveColl.enabled = false;
        door.SetActive(true);
        //endgame
    }
}
