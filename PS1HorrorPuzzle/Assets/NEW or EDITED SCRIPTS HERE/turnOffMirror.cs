using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOffMirror : MonoBehaviour
{
    //Controls how objects collide with the future portal
    public mirrorObject cubeMirror;
    public GameObject glass;
    public bool cubeInPast = false;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Selectable")
        {
            //Resets position of object if it touches the portal
            if (other.gameObject.GetComponent<mirrorObject>() != null)
            {
                other.gameObject.transform.position = other.gameObject.GetComponent<startPosStore>().startPos;
                other.gameObject.transform.rotation = other.gameObject.GetComponent<startPosStore>().startRot;
            }
        } 
    }
    //Seperate function for when the portal is a trigger collider
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Selectable")
        {
            //Resets position of object if it touches the portal
            if (other.gameObject.GetComponent<mirrorObject>() != null)
            {
                other.gameObject.transform.position = other.gameObject.GetComponent<startPosStore>().startPos;
                other.gameObject.transform.rotation = other.gameObject.GetComponent<startPosStore>().startRot;
            }
        }
        else if (other.gameObject.tag == "Player")
        {
            //Should enabled/disable the mirror object script for the past special cube based on if the future special cube is held/in the past
            if(other.gameObject.GetComponent<PlayerMovement>().holding != null)
            {
                if (other.gameObject.GetComponent<PlayerMovement>().holding.gameObject.name == "FutureSpecialCube")
                {
                    cubeMirror.enabled = false;
                    cubeInPast = !cubeInPast;
                }
            }          
            else
            {
                if (!cubeInPast && !glass.activeSelf)
                {
                    cubeMirror.enabled = !cubeMirror.enabled;
                }
            }
        }
    }
}
