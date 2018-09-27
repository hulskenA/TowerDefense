using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    [SerializeField] Waypoint startingWaypoint, endingWaypoint;
    [SerializeField] Color startingWaypointColor, endingWaypointColor;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    Queue<Waypoint> path = new Queue<Waypoint>();
    bool isRunning = true;

    Waypoint searchCenter;

    // Use this for initialization
    void Start () {
        LoadBlocks();
        ColorStartingAndEndingWaypoints();
        Pathfind();
	}

    private void Pathfind()
    {
        path.Enqueue(startingWaypoint);

        while (path.Count > 0 && isRunning)
        {
            searchCenter = path.Dequeue();
            HaltIfEndFind();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }
    }

    private void HaltIfEndFind()
    {
        if (searchCenter.Equals(endingWaypoint))
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            if (!isRunning) { return; }

            Vector2Int neighbourPos = searchCenter.GetGridPos() + direction;
            try
            {
                QueueNewNeighbours(neighbourPos);
            }
            catch { }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourPos)
    {
        Waypoint neighbour = grid[neighbourPos];

        if(!neighbour.isExplored && !path.Contains(neighbour))
        {
            neighbour.SetTopColor(Color.yellow);
            path.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }

    private void ColorStartingAndEndingWaypoints()
    {
        startingWaypoint.SetTopColor(startingWaypointColor);
        endingWaypoint.SetTopColor(endingWaypointColor);
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
            }
            else
            {
                Debug.Log("Skipping overlapping block " + waypoint);
            }
        }

        print("Loaded " + grid.Count + " blocks");
    }
}
