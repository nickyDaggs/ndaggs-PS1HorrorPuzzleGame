using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPosStore : MonoBehaviour
{
    public Vector3 startPos;
    public Quaternion startRot;
    // Start is called before the first frame update
    void Awake()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
