using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;

	// Use this for initialization
	void Start () {
        StartCoroutine(RepeatedlySpawnEnemies());
	}
	
	private IEnumerator RepeatedlySpawnEnemies()
    {
        while(true)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            //enemyPrefab.transform.parent = transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
