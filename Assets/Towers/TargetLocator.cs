using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{

    [SerializeField] ParticleSystem heartGun;
    [SerializeField] float fireRate = 1f;
    public float dmg = 60;
    GameObject enemy;
    bool isFiring = false;
    
    void Start()
    {
        
        enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy)
        {
            AimWeapon();
            if (isFiring == false)
            {
                StartCoroutine(FireWeapon());
            }
        }
    }

    IEnumerator FireWeapon()
    {
        isFiring = true;
        while (enemy)
        {
            heartGun.Emit(1);
            yield return new WaitForSeconds(fireRate);
        }
        isFiring = false;
        Debug.Log(isFiring);
    }

    void AimWeapon()
    {
        transform.rotation = Quaternion.LookRotation(enemy.transform.position - transform.position);
    }
}
