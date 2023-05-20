using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FuturePuzzleCheck : MonoBehaviour
{
    //Checks if all faces in the future have the right cube on them.
    //If that's true, then puzzle is complete and the glass keeping the cube contained is disabled.
    public GameObject glassFuture;
    public List<FaceCheck> faces;
    public mirrorObject cubeMirror;
    public Animator sprite;

    public void Check()
    {
        if(faces.All(a => a.completed))
        {
            sprite.SetTrigger("Complete");
            glassFuture.SetActive(false);
            StartCoroutine(EnabledWait());
            
        }
    }

    IEnumerator EnabledWait()
    {
        yield return new WaitForSeconds(3f);
        cubeMirror.enabled = false;
    }
}
