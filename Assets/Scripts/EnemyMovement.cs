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
        print("Starting patrol...");

        foreach (Waypoint waypoint in pathToFollow)
        {
            transform.position = waypoint.transform.position;
            print("Visiting : " + waypoint);
            yield return new WaitForSeconds(1f);
        }

        print("Ending patrol");
    }
    
}
