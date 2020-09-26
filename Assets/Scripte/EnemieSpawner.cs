using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.AI;

public class EnemieSpawner : MonoBehaviour
{
    public List<GameObject> EnemiPrefab;
    public Transform SpawnPos;
    public Transform DestinationPos;
    public int NombreSpwan;
    public float SpawDelay;
    public int EnemieIndex;
    private int _uniteToSpawn;
    private float _timerSpwan;
  
    // Update is called once per frame
    void Update()
    {
        if (_uniteToSpawn>0)
        {
            _timerSpwan += Time.deltaTime;
            if (_timerSpwan >= SpawDelay)
            {
                GameObject enenmi = Instantiate(EnemiPrefab[EnemieIndex], SpawnPos.position, Quaternion.identity);
                enenmi.GetComponent<NavMeshAgent>().SetDestination(DestinationPos.position);
                _timerSpwan = 0;
                _uniteToSpawn--;
            }
        }
    }
[ContextMenu("Commence Le Spawn")]
    public void StartSpwan()
    {
        _uniteToSpawn = NombreSpwan;
    }
}
