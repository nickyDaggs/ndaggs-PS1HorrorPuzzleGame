using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCheck : MonoBehaviour
{
    public GameObject target;
    public bool completed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject == target)
        {
            //Debug.Log("ffdsa");
            completed = true;


        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject == target)
        {
            completed = false;
        }
    }
}
