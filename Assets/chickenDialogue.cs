using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chickenDialogue : MonoBehaviour
{
    private int dCount;
    public Text dialogue;
    private int apples;
    public GameObject house;

    // Start is called before the first frame update
    void Start()
    {
        dialogue.text = "";
        dCount = 0;
        Debug.Log( GameObject.Find("PlayerCharacter").GetComponent<Move>().applesCollected);
    }

    private void OnMouseDown()
    {
        Debug.Log(GameObject.Find("PlayerCharacter").GetComponent<Move>().applesCollected);


        if (dCount == 0)
        {
            dialogue.text = "Hi! I'm Chicken.";
        } else if (dCount == 1)
        {
            dialogue.text = "Can you help me with somehing?";
        } else if (dCount == 2)
        {
            dialogue.text = "Collect 10 apples for me, I'll build you a nice house!!";
        } else if (GameObject.Find("PlayerCharacter").GetComponent<Move>().applesCollected >= 10)
        {
            GameObject.Find("PlayerCharacter").GetComponent<Move>().applesCollected -= 10;
            dialogue.text = "Wow! Thanks so much. I built your house over there~";
            house.SetActive(true);
        }
        dCount += 1;
  
    }

    // Update is called once per frame
    void Update()
    {

    }
}
