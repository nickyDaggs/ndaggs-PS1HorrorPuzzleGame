using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    //Manages the puzzle in the Quiz Room
    public List<GameObject> answerOrder;
    public bool complete = false;
    int i = 0;
    public Animator sprite;
    public Animator TV;
    public GameObject glass;  

    public void Check(GameObject real)
    {
        //Does animation for button
        real.GetComponentInChildren<Animator>().SetTrigger("Press");
        //Checks if button pressed is correct, gives trigger to animator to react based on whether the answer was correct or not
        if (real == answerOrder[i])
        {
            //increments for the next question
            i++;
            if (i > answerOrder.Count - 1)
            {
                complete = true;
                TV.SetTrigger("Next");
                //removes glass so key can be obtained
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
        }
    }
}
