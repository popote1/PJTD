using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;


public class GameSetter : MonoBehaviour
{
    public TMP_Text Money;
    public  Slider HP;
    [Header("start seting")]
    public int StartHP =100;
    public int StartMoney = 150;

    private void Awake()
    {
        GameManager.money = StartMoney;
        GameManager.HP = StartHP;
    }


    public  void ChangeHP(float hp)
    {
        HP.value = hp / 100;
    }

    public  void Change(int money)
    {
        Money.text = "" + money;
    }
}
