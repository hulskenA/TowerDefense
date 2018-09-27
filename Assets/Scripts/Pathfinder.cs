using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

	// Use this for initialization
	void Start () {
        LoadBlocks();
	}

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            Vector2Int waypointPos = waypoint.GetGridPos();

            if (!grid.ContainsKey(waypointPos))
            {
                grid.Add(waypointPos, waypoint);
                Color waypointColor;
                if (waypoint.IsEndingWaypoint()) {
                    waypointColor = Color.red;
                } else if (waypoint.IsStartingWaypoint())
                {
                    waypointColor = Color.green;
                } else
                {
                    waypointColor = Color.grey;
                }
                waypoint.SetTopColor(waypointColor);
            }
            else
            {
                Debug.Log("Skipping overlapping block " + waypoint);
            }
        }

        print("Loaded " + grid.Count + " blocks");
    }
}
