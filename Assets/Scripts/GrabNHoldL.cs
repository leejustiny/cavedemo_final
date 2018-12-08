using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabNHoldL : MonoBehaviour
{


    public GameObject heldObjectL;

    public Transform handAnchorL;

    public Transform handPosL;

    private bool grabDrop;

    private bool checkBool;
    public OVRGrabber disable2;


    // Update is called once per frame
    void Update()
    {

        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) == true)
        {
            if (grabDrop == true)
            {
                GrabObject(handAnchorL, handPosL);
                checkBool = true;
            }

        }

        if(checkBool == true)
        {
            //heldObjectL.GetComponent<Rigidbody>().ResetInertiaTensor();

            heldObjectL.GetComponent<Rigidbody>().velocity = Vector3.zero;
            heldObjectL.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
        

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
        {
            
            DropObject();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickaxe"))
        {
            heldObjectL = other.gameObject;
            grabDrop = true;
        }
        else
        {
            grabDrop = false;
        }
    }


    void Start()
    {
        disable2 = GetComponent<OVRGrabber>();
    }

    public void GrabObject(Transform anchor, Transform pos)
    {
        //Debug.Log("Grabbed");

     //   heldObjectL.GetComponent<Rigidbody>().ResetInertiaTensor();
        heldObjectL.transform.SetPositionAndRotation(pos.position, pos.rotation);
        heldObjectL.transform.SetParent(anchor);
        disable2.enabled = false;
        heldObjectL.GetComponent<Rigidbody>().velocity = Vector3.zero;
        heldObjectL.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        heldObjectL.GetComponent<Rigidbody>().useGravity = false;
        heldObjectL.GetComponent<Rigidbody>().isKinematic = false;
        grabDrop = false;
        checkBool = true;
    }

    public void DropObject()
    {
      //  Debug.Log("dropStart");

        if (heldObjectL != null)
        {
 

       //     Debug.Log("Dropped");

            heldObjectL.transform.SetParent(null);
            heldObjectL.GetComponent<Rigidbody>().ResetInertiaTensor();
            heldObjectL.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            heldObjectL.GetComponent<Rigidbody>().useGravity = true;
            heldObjectL.GetComponent<Rigidbody>().isKinematic = false;
            disable2.enabled = true;
            checkBool = false;
              heldObjectL = null;
        }

    }
}
