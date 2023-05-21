using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCheck : MonoBehaviour
{
    //For checking when a correct object is touching this object
    //Used in the faces for the Future Room and the numbered cubes that you put the keys on
    public GameObject target;
    public bool completed = false;

    //completed when target object is touching
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject == target)
        {
            completed = true;
        }
    }

    //uncompleted when target object stops touching
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject == target)
        {
            completed = false;
        }
    }
}
