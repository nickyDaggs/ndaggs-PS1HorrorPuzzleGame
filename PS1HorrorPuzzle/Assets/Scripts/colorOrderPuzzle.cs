using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorOrderPuzzle : MonoBehaviour
{
    public List<GameObject> correctOrder;
    public Animator sprite;
    int i = 0;
    public bool complete;

    private static colorOrderPuzzle _instance;
    public static colorOrderPuzzle Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<colorOrderPuzzle>();
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
        
    }

    public void Check(GameObject button)
    {
        button.GetComponentInChildren<Animator>().SetTrigger("Press");
        if(button == correctOrder[i])
        {
            i++;
            if(i > correctOrder.Count - 1)
            {
                complete = true;
                sprite.SetTrigger("Complete");
            } else
            {
                sprite.SetTrigger("Correct");
            }
        } else
        {
            sprite.SetTrigger("Wrong");
            i = 0;
        }
    }
}
