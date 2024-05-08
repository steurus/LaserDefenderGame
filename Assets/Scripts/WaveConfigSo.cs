using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(menuName ="Wave Config",fileName ="New Wave Config")]
public class WaveConfigSo : ScriptableObject
{
    [SerializeField] List <GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed =5F;
    [SerializeField] float timeBetweenEnemySpawns=1f;
    [SerializeField] float spawnTimeVariance=0f;
    [SerializeField] float minimumSpawnTime=0.2f;

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefabs(int index)
    {
        return enemyPrefabs[index];
    }

    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints=new List<Transform>();
        foreach(Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }
    
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetRandomSpwanTime()
    {
        float spawnTime=Random.Range(timeBetweenEnemySpawns-spawnTimeVariance,
        timeBetweenEnemySpawns+spawnTimeVariance);
        return Mathf.Clamp(spawnTime,minimumSpawnTime,float.MaxValue);
    }
}
