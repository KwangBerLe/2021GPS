﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private CharacterController cc;
    public float gravity = -9.8f;
    float velocity;
    public float jumpPower = 5;

    private bool isJump = false;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();

        if(cc.collisionFlags == CollisionFlags.Below)
        {
            velocity = 0;
            isJump = false;
            /*if (Input.GetButtonDown("Jump"))
            {
                velocity = jumpPower;
            }*/
        }
        if (!isJump && Input.GetButtonDown("Jump"))
        {
            velocity = jumpPower;
            isJump = true;
        }
        velocity += gravity * Time.deltaTime;
        dir.y = velocity;
        /*dir = Camera.main.transform.TransformDirection(dir);
        카메라 회전값에 따른 방향벡터를 바꾼다.*/

        cc.Move(dir * moveSpeed * Time.deltaTime);
    }
}