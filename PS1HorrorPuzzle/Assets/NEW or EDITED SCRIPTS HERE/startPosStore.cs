using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPosStore : MonoBehaviour
{
    //Holds the starting position at the beginning of the scene. Used to reset position of object if it touches the future portal
    public Vector3 startPos;
    public Quaternion startRot;

    void Awake()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

}
