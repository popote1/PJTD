using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.CompareTag("Enemi"))
        {
            GameManager.EnemieToGoal(other.GetComponent<UniteMove>().EnemieInfo.Damage);
            Destroy(other.gameObject);
        }
    }
}
