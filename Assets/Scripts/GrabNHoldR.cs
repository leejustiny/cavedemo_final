using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabNHoldR : MonoBehaviour
{


    public GameObject heldObjectR;

    public Transform handAnchorR;

    public Transform handPosR;

    private bool grabDrop;
    public bool checkBool;

    public OVRGrabber disable;


    // Update is called once per frame
    void Update()
    {
        
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger) == true)
        {
            if (grabDrop == true)
            {
                GrabObject(handAnchorR, handPosR);
                checkBool = true;
            }
        }

        if (checkBool == true)
        {

            //heldObjectR.GetComponent<Rigidbody>().ResetInertiaTensor();
            heldObjectR.GetComponent<Rigidbody>().velocity = Vector3.zero;
            heldObjectR.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }

      

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) == true)
        {
            DropObject();
        }


      

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("flashlight"))
        {
            heldObjectR = other.gameObject;
            grabDrop = true;
            
        }
        else
        {
            grabDrop = false;
        }
    }

   
    void Start()
    {
        disable = GetComponent<OVRGrabber>();
    }

    public void GrabObject(Transform anchor, Transform pos)
    {
       // Debug.Log("Grabbed");
        //heldObjectR.GetComponent<Rigidbody>().ResetInertiaTensor();
        heldObjectR.transform.SetPositionAndRotation(pos.position, pos.rotation);
        heldObjectR.transform.SetParent(anchor);
        disable.enabled = false;
        heldObjectR.GetComponent<Rigidbody>().velocity = Vector3.zero;
        heldObjectR.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        heldObjectR.GetComponent<Rigidbody>().useGravity = false;
        heldObjectR.GetComponent<Rigidbody>().isKinematic = false;
        grabDrop = false;
        checkBool = true;

    }

    public void DropObject()
    {
     //   Debug.Log("dropStart");

        if (heldObjectR != null)
        {


        //    Debug.Log("Dropped");

            heldObjectR.transform.SetParent(null);
            heldObjectR.GetComponent<Rigidbody>().ResetInertiaTensor();
            heldObjectR.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            heldObjectR.GetComponent<Rigidbody>().useGravity = true;
            heldObjectR.GetComponent<Rigidbody>().isKinematic = false;
            disable.enabled = true;
            checkBool = false;
             heldObjectR = null;
        }

    }

}

