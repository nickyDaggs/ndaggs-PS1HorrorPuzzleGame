using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorObject : MonoBehaviour
{
    //Mirrors two objects based on a point
    public Transform ObjA;
    public Transform ObjB;

    public Transform MirrorPoint;

    private void Update()
    {
        //Keeps the same X and Y positions for each object, uses LerpUnclamped to mirror the Z positions based on MirrorPoint
        ObjB.position = new Vector3(ObjA.position.x, ObjA.position.y, Vector3.LerpUnclamped(ObjA.position, MirrorPoint.position, 2f).z);
        //Opposite rotation
        ObjB.rotation = Quaternion.Inverse(ObjA.rotation);
    }
}
