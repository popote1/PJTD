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
            }else if (value <= 0)
            {
                _hpvalue = 0;
                GameOvers();
            }
            else
            {
                _hpvalue = value;}
            
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

    
    // Element UI
    private static TMP_Text _money;
    private static  Slider _hp;
    private static Button _StartwavesBP;
    
    // Element Systeme
    public static List<GameObject> Enemis =new List<GameObject>();
    public static bool _SpawnerEnd;
    private static GameObject _spawner1;
    private static GameObject _spawner2;
    private static List<SOwaives> _waves;
    private static bool _waveEnd;
    private static int _wave=0;
    
    public static void EnnemiKill(int moneyOfKill)
    {
        Money += moneyOfKill;
    }
    public static void EnemieToGoal(int damage)
    {
        NombrePasser++;
        HP -= damage;
        Debug.Log(NombrePasser + "Enemis Sont passé !");
    }

    public static void SetUI(TMP_Text money, Slider hp,Button startWaveBP)
    {
        _money = money;
        _hp = hp;
        _StartwavesBP = startWaveBP;
    }

    public static void SetSpawnSyteme(List<SOwaives> waves, GameObject spawner1, GameObject spawner2)
    {
        _waves = waves;
        _spawner1 = spawner1;
        _spawner2 = spawner2;
    }
    public static void ChangeHP()
    {
        //_hp.value =Mathf.Lerp(_hp.value, HP / 100,0.3f);
        _hp.value =((float)HP)/100;
        
    }

    public static  void ChangeMoney()
    {
        _money.text = "" + Money;
    }

    private static void GameOvers()
    {
        Debug.Log("GameOver");
    }

    public static void StartSpawn()
    {
        _spawner1.GetComponent<EnemieSpawner>().CurrentWave = _waves[_wave];
        _spawner2.GetComponent<EnemieSpawner>().CurrentWave = _waves[_wave];
        _spawner1.GetComponent<EnemieSpawner>().StartSpwan();
        _spawner2.GetComponent<EnemieSpawner>().StartSpwan();
        _StartwavesBP.gameObject.SetActive(false);
    }

    public static void CheckIfWaveEnded()
    {
        if (_SpawnerEnd)
        {
            if (Enemis.Count == 0)
            {
                _wave++;
                _StartwavesBP.gameObject.SetActive(true);
            }

        }
    }
}
