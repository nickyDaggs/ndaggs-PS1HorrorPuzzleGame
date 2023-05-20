using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FutureKeyCheck : MonoBehaviour
{
    public List<PadCheck> pads;
    public GameObject keyGlass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pads.All(a => a.completed))
        {
            keyGlass.SetActive(false);
        }
    }
}
