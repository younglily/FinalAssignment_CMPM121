using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject playerCharacter;
    private Vector3 distance;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float ex = 0.0f;
    private float wai = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - playerCharacter.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerCharacter.transform.position + distance;
        ex += speedH * Input.GetAxis("Mouse X");
        wai -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(wai, ex, 0.0f);
    }
}
