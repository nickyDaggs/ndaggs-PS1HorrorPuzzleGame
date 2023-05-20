using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockScript : MonoBehaviour
{
    public string key;
    public PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == key)
        {
            player.holding = null;
            player.throwable = false;
            Destroy(other.gameObject);
            GetComponent<Animator>().SetTrigger("Next");
        }
    }
}
