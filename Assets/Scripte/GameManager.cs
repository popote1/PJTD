using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public static class GameManager
{
    public static int NombrePasser=0;
    public static int HP;
    public static int money;
    

    public static void EnemieToGoal()
    {
        NombrePasser++;
        Debug.Log(NombrePasser + "Enemis Sont passé !");
    }
}
