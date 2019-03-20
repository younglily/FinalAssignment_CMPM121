using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    private float speed;
    private float respawnDelay;
    private CharacterController character;
    private Animator anim;

    public int applesCollected;
    public int bananasCollected;
    public int pearsCollected;

    public Text totalApples;
    public Text totalPears;
    public Text totalBananas;

    private float startTime;  

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        applesCollected = 0;
        bananasCollected = 0;
        pearsCollected = 0;
        totalApples.text = "";
        totalPears.text = "";
        totalBananas.text = "";
   
        anim = GetComponent<Animator>();
        
    }

    private void respawn(Collider fruit)
    {
        while (respawnDelay > 0  && fruit.enabled == false)
        {
            respawnDelay -= Time.deltaTime;
            Debug.Log(respawnDelay);
        }

        fruit.gameObject.SetActive(true);
        respawnDelay = 0;
    }

    //collecting fruits
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            other.gameObject.SetActive(false);
            applesCollected += 1;
            
            //respawn(other);
        }
        if (other.gameObject.CompareTag("Banana"))
        {
            other.gameObject.SetActive(false);
            bananasCollected += 1;
        }
        if (other.gameObject.CompareTag("Pear"))
        {
            other.gameObject.SetActive(false);
            pearsCollected += 1;
        }

        startTime = Time.time;
        //
        if (startTime >= 10.0)
        {
            startTime = 0;
            other.gameObject.SetActive(true);
        }
    }
    
    public int Apples()
    {
        return applesCollected;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        character.Move(movement);
        transform.rotation = Quaternion.LookRotation(movement);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);


        totalApples.text = "Apples:" + applesCollected.ToString();
        totalBananas.text = "Bananas:" + bananasCollected.ToString();
        totalPears.text = "Pears:" + pearsCollected.ToString();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (null != anim)
            {
                anim.Play("run");
            }
        }
    }
}
