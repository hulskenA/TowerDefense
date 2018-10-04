using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints < 1)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints -= 1;
        hitParticlePrefab.Play();
    }

    private void KillEnemy()
    {
        ParticleSystem deathParticlesFX = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        float deathParticlesFXDuration = deathParticlesFX.main.duration;

        deathParticlesFX.Play();

        Destroy(deathParticlesFX.gameObject, deathParticlesFXDuration);
        Destroy(gameObject);
    }

}
