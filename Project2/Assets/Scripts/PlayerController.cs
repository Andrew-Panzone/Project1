using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float rotationAmount;

    private float playerSpeed;

    private GameObject can;
    // Start is called before the first frame update
    void Start()
    {
        rotationAmount = 10f;
        playerSpeed = 0.0075f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(playerSpeed, 0, 0);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(-playerSpeed, 0, 0);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(0, 0, playerSpeed);
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(0, 0, -playerSpeed);
        }
        
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(0, playerSpeed, 0);
        }
        
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(0, -playerSpeed, 0);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -rotationAmount, 0);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(0, rotationAmount, 0);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (can != null)
            {
                Destroy(can);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        can = other.gameObject;
    }
    
    private void OnTriggerExit(Collider other)
    {
        can = null;
    }
}
