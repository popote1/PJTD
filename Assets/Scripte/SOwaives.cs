using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Wave", menuName = "TDWave")]
public class SOwaives :ScriptableObject
{
   public List<GameObject> Enemis;
   public float SpawnRate;
}
