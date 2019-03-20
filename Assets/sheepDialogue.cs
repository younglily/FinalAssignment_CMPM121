using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sheepDialogue : MonoBehaviour
{
    private int dCount;
    public Text dialogue;
    private int pears;
    public GameObject flowers2;
    public GameObject house;

    // Start is called before the first frame update
    void Start()
    {
        dialogue.text = "";
        dCount = 0;
        Debug.Log(GameObject.Find("PlayerCharacter").GetComponent<Move>().pearsCollected);
    }

    private void OnMouseDown()
    {
        Debug.Log(GameObject.Find("PlayerCharacter").GetComponent<Move>().pearsCollected);

        if (house.activeSelf == true)
        {
            if (dCount == 0)
            {
                dialogue.text = "Hi! I'm Sheep.";
            }
            else if (dCount == 1)
            {
                dialogue.text = "Can you help me with something?";
            }
            else if (dCount == 2)
            {
                dialogue.text = "Collect 15 pears for me, and I'll plant some flowers for you!!";
            }
            else if (GameObject.Find("PlayerCharacter").GetComponent<Move>().pearsCollected >= 15)
            {
                GameObject.Find("PlayerCharacter").GetComponent<Move>().pearsCollected -= 15;
                dialogue.text = "Yay! Thanks. Go check out your flowers!";
                flowers2.SetActive(true);
            }
            dCount += 1;
        }
        else
        {
            dialogue.text = "Hi, I'm Sheep! You still don't have a house yet?? I would go talk to Chicken first.";
            dCount += 1;
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
