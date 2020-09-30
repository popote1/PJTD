using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Tourelle", menuName = "TDTourelle")]
public class SOTourel : ScriptableObject
{
   public string Name;
   public float Range;
   public float FireRate;
   public float Cost;
   public int Damage;
   public enum _specialType {Leger , normal , Blinder}

   public _specialType SpecialType;
   public int SpecialDamage;
}
