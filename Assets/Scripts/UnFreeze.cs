using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnFreeze : MonoBehaviour {

    public GameObject diamond;
    public Rigidbody diamondRB;
    
	// Use this for initialization
	void Start () {
        //diamond = GameObject.
        //diamondRB = diamond.GetComponent<Rigidbody>();
	}


    private void OnCollisionEnter(Collision hands)
    {
        if(hands.gameObject.GetComponent<Collider>() == GameObject.Find("RightHandAnchor").GetComponent<Collider>())
        {
            diamondRB.constraints = RigidbodyConstraints.None;
        }
        if (hands.gameObject.GetComponent<Collider>() == GameObject.Find("LeftHandAnchor").GetComponent<Collider>())
        {
            diamondRB.constraints = RigidbodyConstraints.None;
        }
    } 
   
    // Update is called once per frame
    void Update () {
		
	}
}
