using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.AI;

public class EnemieSpawner : MonoBehaviour
{
    //§public List<GameObject> EnemiPrefab;
    public SOwaives CurrentWave;
    public Transform DestinationPos;
   /* public int NombreSpwan;
    public float SpawDelay;
    public int EnemieIndex;*/
    private int _enemieIndex;
    private float _spawnDelay;
    private int _uniteToSpawn;
    private float _timerSpwan;

    // Update is called once per frame
    void Update()
    {
        if (_uniteToSpawn>0)
        {
            _timerSpwan += Time.deltaTime;
            if (_timerSpwan >= _spawnDelay)
            {
                GameObject enenmi = Instantiate(CurrentWave.Enemis[_enemieIndex],transform.position, Quaternion.identity);
                enenmi.GetComponent<NavMeshAgent>().SetDestination(DestinationPos.position);
                GameManager.Enemis.Add(enenmi);
                _timerSpwan = 0;
                _enemieIndex++;
                _uniteToSpawn--;
            }
        }
        else
        {
            GameManager._SpawnerEnd = true;
        }
    }
[ContextMenu("Commence Le Spawn")]
    public void StartSpwan()
    {
        _uniteToSpawn = CurrentWave.Enemis.Count;
        _enemieIndex = 0;
        _spawnDelay = CurrentWave.SpawnRate;

    }
}
