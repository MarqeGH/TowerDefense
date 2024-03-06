using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] float moveSpeed = 1;
    Vector3 enemyPlacement;

    void Start()
    {
        StartCoroutine(MoveEnemyByPath());
        enemyPlacement = transform.position;
    }
    
    IEnumerator MoveEnemyByPath()
    {
        foreach(WayPoint waypoint in path)
        {
            Debug.DrawLine(transform.position, waypoint.transform.position, Color.red, 10);
            transform.rotation = Quaternion.LookRotation(waypoint.transform.position - transform.position);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(moveSpeed);
        }
    }
}