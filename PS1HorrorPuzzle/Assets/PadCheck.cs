using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadCheck : MonoBehaviour
{
    public bool turnOnFuture = false;
    public bool completed = false;
    public Material portalMat;
    public Material otherMat;
    public Collider realPortal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name + other.gameObject.name.Contains("SpecialCube"));
        if(other.gameObject.name.Contains("SpecialCube"))
        {
            completed = true;
            if(turnOnFuture)
            {
                realPortal.isTrigger = true;
                realPortal.GetComponent<MeshRenderer>().material = portalMat;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("SpecialCube"))
        {
            completed = false;
            if (turnOnFuture)
            {
                realPortal.isTrigger = false;
                realPortal.GetComponent<MeshRenderer>().material = otherMat;
            }
        }
    }
}
