using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadCheck : MonoBehaviour
{
    //Checks if a special cube is on in order to turn on the portal to the future or to deactivate the glass holding the purple key
    public bool turnOnFuture = false;
    public bool completed = false;
    public Material portalMat;
    public Material otherMat;
    public Collider realPortal;

    private void OnTriggerEnter(Collider other)
    {
        //Checks for special cube based on name
        if(other.gameObject.name.Contains("SpecialCube"))
        {
            completed = true;
            if(turnOnFuture)
            {
                //turning the portal into a trigger allows the player to pass through it
                realPortal.isTrigger = true;
                realPortal.GetComponent<MeshRenderer>().material = portalMat;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //turns off portal/makes it uncomplete
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
