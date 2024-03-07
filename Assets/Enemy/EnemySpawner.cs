using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemySpawner : MonoBehaviour
{
    public List<WayPoint> epath = new List<WayPoint>();
    [SerializeField] GameObject enemyType;
    [SerializeField] float timeTillNextSpawn = 1f;
    GameObject enemyHolder;
    GameObject parent;

    // Start is called before the first frame update
    // void Start()
    // {
    //     parent = GameObject.Find("EnemyHolder");
    //     StartCoroutine(SpawnEnemy());
    // }


    // // Update is called once per frame

    // IEnumerator SpawnEnemy()
    // {
    //     for (int i = 0; i < 20; ++i)
    //     {
    //     enemyHolder = Instantiate(enemyType, transform.position, Quaternion.identity);
    //     enemyHolder.transform.parent = parent.transform;
    //     yield return new WaitForSeconds(timeTillNextSpawn);
    //     }
    // }

}
