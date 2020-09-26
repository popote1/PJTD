using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemi", menuName = "TDEnemi")]
public class SOEnemie : ScriptableObject
{
    public string Name;
    public int HP;
    public enum _armor { leger,normal, Blinder }
    public _armor Armor;
    public float MoveSpeed;
    public enum _attckType {CAC , Distance}
    public _attckType AttckType;
}
