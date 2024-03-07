using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] GameObject tower1Default;
    void OnMouseDown()
    {
        if(isPlaceable)
        {
            Instantiate(tower1Default, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }

}
