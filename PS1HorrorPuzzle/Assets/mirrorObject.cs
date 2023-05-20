using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorObject : MonoBehaviour
{
    public Transform ObjA;
    public Transform ObjB;

    public Transform MirrorPoint;

    private void Update()
    {
        ObjB.position = new Vector3(ObjA.position.x, ObjA.position.y, Vector3.LerpUnclamped(ObjA.position, MirrorPoint.position, 2f).z);
        ObjB.rotation = Quaternion.Inverse(ObjA.rotation);
        //ObjB.position = Vector3.LerpUnclamped(ObjA.position, MirrorPoint.position, 2f);//new Vector3()Vector3.LerpUnclamped(ObjA.position, MirrorPoint.position, 2f).z;
    }
}
