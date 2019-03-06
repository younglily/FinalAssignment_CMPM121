using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed;
    private CharacterController character;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();

        anim = GetComponent<Animator>();

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

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (null != anim)
            {
                anim.Play("run");
            }
        }
    }
}
