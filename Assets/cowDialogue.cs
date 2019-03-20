using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cowDialogue : MonoBehaviour
{
    private int dCount;
    public Text dialogue;
    private int bananas;
    public GameObject flowers1;
    public GameObject house;

    // Start is called before the first frame update
    void Start()
    {
        dialogue.text = "";
        dCount = 0;
        Debug.Log(GameObject.Find("PlayerCharacter").GetComponent<Move>().bananasCollected);
    }

    private void OnMouseDown()
    {
        Debug.Log(GameObject.Find("PlayerCharacter").GetComponent<Move>().bananasCollected);

        if (house.activeSelf == true)
        {
            if (dCount == 0)
            {
                dialogue.text = "Hi! I'm Cow.";
            }
            else if (dCount == 1)
            {
                dialogue.text = "Can you help me with something?";
            }
            else if (dCount == 2)
            {
                dialogue.text = "Collect 15 bananas for me, and I'll plant some flowers for you!!";
            }
            else if (GameObject.Find("PlayerCharacter").GetComponent<Move>().bananasCollected >= 15)
            {
                GameObject.Find("PlayerCharacter").GetComponent<Move>().bananasCollected -= 15;
                dialogue.text = "Yay! Thanks. Go check out your flowers!";
                flowers1.SetActive(true);
            }
            dCount += 1;
        } else
        {
            dialogue.text = "Hi, I'm Cow! You still don't have a house yet?? I would go talk to Chicken first.";
            dCount += 1;
        }
        

    }

    // Update is called once per frame
    void Update()
    {

    }
}
