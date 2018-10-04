using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] ParticleSystem goalReachedParticlePrefab;
    [SerializeField] float movementPeriod = 1f;

    // Use this for initialization
    void Start () {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        Stack<Waypoint> pathToFollow = pathfinder.GetPath();
        StartCoroutine(FollowPath(pathToFollow));
    }

    private IEnumerator FollowPath(Stack<Waypoint> pathToFollow)
    {
        foreach (Waypoint waypoint in pathToFollow)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }

        ProcessGoalReached();
    }

    private void ProcessGoalReached()
    {
        ParticleSystem goalReachedParticlesFX = Instantiate(goalReachedParticlePrefab, transform.position, Quaternion.identity);
        float goalReachedParticlesFXDuration = goalReachedParticlesFX.main.duration;

        goalReachedParticlesFX.Play();

        Destroy(goalReachedParticlesFX.gameObject, goalReachedParticlesFXDuration);
        Destroy(gameObject);
    }

}
