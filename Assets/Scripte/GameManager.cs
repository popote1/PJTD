using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Assertions.Comparers;

public static class GameManager
{
    public static int NombrePasser=0;
    public static int HP
    {
        get => HP;
        set
        {
            if (value > 100)
            {
                HP = 100;
            }else if (value < 0)
            {
                HP = 0;
                GameOvers();
            }
            ChangeHP();
        }
    }

    public static int Money
    {
        get => Money;
        set
        {
            Money = value;
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
