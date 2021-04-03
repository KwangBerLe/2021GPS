﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Hp : MonoBehaviour
{
    private Text hpText;
    private int playerHP = 3;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>(); // Player 클래스를 찾아가는 함수에요!
        hpText = GetComponent<Text>();
        playerHP = player.GetHP();
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "HP : " + player.GetHP();
    }
}