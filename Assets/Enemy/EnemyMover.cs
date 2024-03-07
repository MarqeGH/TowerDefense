using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;

    Vector3 enemyPlacement;
    // public NavMeshAgent enemy;
    // public GameObject targetTile;
    List <WayPoint> path;
    GameObject enemySpawner;
    Animator enemyAnimator;
    Animation currentAnimation;
    BoxCollider enemyCollider;

    void Start()
    {
        // enemySpawner = GameObject.Find("Enemy Spawner");
        enemyCollider = GetComponent<BoxCollider>();
        enemyPlacement = transform.position;
        path = GetComponent<EnemySpawner>().epath;
        StartCoroutine(MoveEnemyByPath());
        enemyAnimator = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // Vector3 targetDoorPosition = targetTile.transform.position;
        // enemy.SetDestination(targetDoorPosition);
        // Debug.DrawLine(transform.position, targetTile.transform.position, Color.red, 10);
    }
    
    
    IEnumerator MoveEnemyByPath()
     {
         foreach(WayPoint waypoint in path)
         {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;
            transform.LookAt(endPosition);

            while(travelPercent < 1f) {
                travelPercent += Time.deltaTime*moveSpeed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
            // Debug.DrawLine(transform.position, waypoint.transform.position, Color.red, 10);
            // transform.rotation = Quaternion.LookRotation(waypoint.transform.position - transform.position);
            // transform.position = waypoint.transform.position;
                yield return new WaitForEndOfFrame();
            }
        }
        enemyAnimator.Play("Death");
        yield return new WaitForSeconds(1);
        DestroySelf();
     }
    void DestroySelf ()
    {
        Destroy(gameObject);
    }

}