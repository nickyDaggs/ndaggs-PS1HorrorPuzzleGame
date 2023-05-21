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
    //Have to deactivate the mirror object so the special cube in the future can be held by the player. 
    //Need to wait a few seconds to deactivate or else the special cube spazzes around due to the glass collider
    IEnumerator EnabledWait()
    {
        yield return new WaitForSeconds(3f);
        cubeMirror.enabled = false;
    }
}
