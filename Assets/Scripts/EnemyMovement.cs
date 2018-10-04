using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    
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
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        
    }
}
