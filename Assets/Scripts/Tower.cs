using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange;
    [SerializeField] ParticleSystem projectileParticle;

    Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;
        EnemyDamage testEnemy;
        for (int indexEnemy = 1; indexEnemy < sceneEnemies.Length; indexEnemy++)
        {
            testEnemy = sceneEnemies[indexEnemy];
            float distanceToTestEnemy = Vector3.Distance(testEnemy.transform.position, gameObject.transform.position);
            float distanceToClosestEnemy = Vector3.Distance(closestEnemy.transform.position, gameObject.transform.position);
            if (distanceToTestEnemy < distanceToClosestEnemy)
            {
                closestEnemy = testEnemy.transform;
            }
        }

        targetEnemy = closestEnemy;
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
