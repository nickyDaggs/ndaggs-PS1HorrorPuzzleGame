using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<GameObject> answerOrder;
    public bool complete = false;
    int i = 0;
    public Animator sprite;
    public Animator TV;
    public GameObject glass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Check(GameObject real)
    {
        Debug.Log("real");
        real.GetComponentInChildren<Animator>().SetTrigger("Press");
        if (real == answerOrder[i])
        {
            i++;
            if (i > answerOrder.Count - 1)
            {
                complete = true;
                TV.SetTrigger("Next");
                glass.SetActive(false);
                sprite.SetTrigger("Complete");
            }
            else
            {
                TV.SetTrigger("Next");
                sprite.SetTrigger("Good");
            }
        }
        else
        {
            sprite.SetTrigger("Bad");
            i = 0;
        }
    }
}
