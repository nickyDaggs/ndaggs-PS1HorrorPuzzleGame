using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FutureKeyCheck : MonoBehaviour
{
    //Checks if both pads for the Future Room are complete in order to deactivate the glass holding the key
    public List<PadCheck> pads;
    public GameObject keyGlass;

    void Update()
    {
        if(pads.All(a => a.completed))
        {
            keyGlass.SetActive(false);
        }
    }
}
