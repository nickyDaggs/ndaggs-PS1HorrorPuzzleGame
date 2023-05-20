using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class pipePuzzle : MonoBehaviour
{
    public bool complete;
    public List<Animator> pipes = new List<Animator>();
    public Animator container;
    

    private static pipePuzzle _instance;
    public static pipePuzzle Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<pipePuzzle>();
            }

            return _instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(pipes.Where(x => x.GetCurrentAnimatorStateInfo(0).IsName("pipeIdle")).Count() == pipes.Count && !complete)
        {
            complete = true;
            container.SetTrigger("Next");
            foreach (Animator pipe in pipes)
            {
                pipe.enabled = false;

            }
        }
    }
}
