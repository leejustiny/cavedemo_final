using System.Collections;
using UnityEngine;

public class ReplaceOre : MonoBehaviour
{

    public GameObject ore;
    public GameObject diamond;
    public GameObject outer;



    void Start()
    {
        
    }

    public void ReplaceWithDiamond(Collider gObj)
    {
        outer = gObj.gameObject;
        ore = outer.transform.GetChild(0).gameObject;
        diamond = outer.transform.GetChild(1).gameObject;
        ore.SetActive(false);
        diamond.SetActive(true);
        diamond.GetComponent<Rigidbody>().velocity = Vector3.zero;
        diamond.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Replace"))
        {
            ReplaceWithDiamond(collision);
        }
    }
}