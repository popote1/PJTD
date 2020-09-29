using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Assertions.Comparers;

public static class GameManager
{
    public static int NombrePasser=0;
    private static int _hpvalue;
    public static int HP
    {
        get => _hpvalue;
        set
        {
            if (value > 100)
            {
                _hpvalue = 100;
            }else if (value < 0)
            {
                _hpvalue = 0;
                GameOvers();
            }
            ChangeHP();
        }
    }

    private static int _moneyValue;
    public static int Money
    {
        get => _moneyValue;
        set
        {
           _moneyValue = value;
            ChangeMoney();
        }
    }

    private static TMP_Text _money;
    private static  Slider _hp;
    

    public static void EnemieToGoal(int damage)
    {
        NombrePasser++;
        HP -= damage;
        Debug.Log(NombrePasser + "Enemis Sont passé !");
    }

    public static void SetUI(TMP_Text money, Slider hp)
    {
        _money = money;
        _hp = hp;
    }
    public static void ChangeHP()
    {
        _hp.value =Mathf.Lerp(_hp.value, HP / 100,0.3f);
    }

    public static  void ChangeMoney()
    {
        _money.text = "" + Money;
    }

    private static void GameOvers()
    {
        Debug.Log("GameOver");
    }
}
