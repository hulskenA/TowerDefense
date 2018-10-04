using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] Transform parentTransform;
    [SerializeField] EnemyMovement enemyPrefab;

	// Use this for initialization
	void Start () {
        StartCoroutine(RepeatedlySpawnEnemies());
	}
	
	private IEnumerator RepeatedlySpawnEnemies()
    {
        while(true)
        {
            EnemyMovement newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = parentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

}
