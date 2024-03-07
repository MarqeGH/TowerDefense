using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxHP = 100;

    float turretDmg;
    float currentHP;
    void Start()
    {
        currentHP = maxHP;
        turretDmg = GameObject.Find("EnemyHolder").GetComponent<TurretDamage>().turret1Dmg;
    }

    // Update is called once per frame
    void OnParticleCollision(GameObject particle) {
        currentHP -= turretDmg;
        Debug.Log(currentHP);
    }
}
