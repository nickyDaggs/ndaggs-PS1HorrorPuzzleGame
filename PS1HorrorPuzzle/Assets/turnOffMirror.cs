using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOffMirror : MonoBehaviour
{
    public mirrorObject cubeMirror;
    public GameObject glass;
    public bool cubeInPast = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Selectable")
        {
            if(other.gameObject.GetComponent<mirrorObject>() != null)
            {
                other.gameObject.transform.position = other.gameObject.GetComponent<startPosStore>().startPos;
                other.gameObject.transform.rotation = other.gameObject.GetComponent<startPosStore>().startRot;
            }
        } 
        /*else if(other.gameObject.tag == "Player")
        {
            Debug.Log("fffd");
            if(other.gameObject.GetComponent<PlayerMovement>().holding.gameObject.name == "FutureSpecialCube")
            {
                cubeMirror.enabled = false;
                cubeInPast = !cubeInPast;
            } else
            {
                if(!cubeInPast)
                {
                    cubeMirror.enabled = !cubeMirror.enabled;
                }
            }
        }*/
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Selectable")
        {
            if (other.gameObject.GetComponent<mirrorObject>() != null)
            {
                other.gameObject.transform.position = other.gameObject.GetComponent<startPosStore>().startPos;
                other.gameObject.transform.rotation = other.gameObject.GetComponent<startPosStore>().startRot;
            }
        }
        else if (other.gameObject.tag == "Player")
        {
            //Debug.Log("fffd");
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
