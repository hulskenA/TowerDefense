using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] Transform parentTransform;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip spawnedEnemySFX;

    int enemiesCounter = 0;

    // Use this for initialization
    void Start () {
        healthText.text = enemiesCounter.ToString();
        StartCoroutine(RepeatedlySpawnEnemies());
	}
	
	private IEnumerator RepeatedlySpawnEnemies()
    {
        while(true)
        {
            EnemyMovement newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = parentTransform;

            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            enemiesCounter++;
            healthText.text = enemiesCounter.ToString();

            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

}
