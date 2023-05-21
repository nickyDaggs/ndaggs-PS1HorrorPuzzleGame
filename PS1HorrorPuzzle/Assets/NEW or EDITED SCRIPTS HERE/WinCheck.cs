using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class WinCheck : MonoBehaviour
{
    //Just checks if all the cubes to put the keys on are in the right order which means the game is completed
    public List<FaceCheck> keyBlocks;

    // Update is called once per frame
    void Update()
    {
        if(keyBlocks.TrueForAll(a => a.completed))
        {
            //Loads the ending screen
            SceneManager.LoadScene(2);
        }
    }
}
