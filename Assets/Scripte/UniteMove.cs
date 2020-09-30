using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UniteMove : MonoBehaviour
{
    
    private NavMeshAgent _agent;
    public SOEnemie EnemieInfo;
    public int Type;
    public string Name;

    private int _hp;

    public int HP
    {
        get { return _hp;}
        set
        {
            Debug.Log(" Hp = "+value);
            if (value <= 0)
            {
                _hp = 0;
                Die();
            }
            else
            {
                _hp=value;
            }
        }

    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        
        _agent.speed =EnemieInfo.MoveSpeed;
        switch (EnemieInfo.Armor)
        {case SOEnemie._armor.leger : Type = 1;
            break;
        case  SOEnemie._armor.normal : Type = 2;
            break;
        case SOEnemie._armor.Blinder : Type = 3;
            break;
        }

        Name = EnemieInfo.Name;
        HP = EnemieInfo.HP;

    }

    // Update is called once per frame

    public void TakeDamage(int damage, int spType, int spDamage)
    {
        if (spType == Type)
        {
            HP -= spDamage;
        }
        else
        {
            HP -= damage;
        }
    }

    public void TakeDamge(int damage)
    {
        HP -= damage;
    }

    private void Die()
    {
        GameManager.EnnemiKill(EnemieInfo.MoneyForKill);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameManager.Enemis.Remove(gameObject);
        GameManager.CheckIfWaveEnded();
    }
}

