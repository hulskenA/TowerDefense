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
    Queue<Waypoint> queue = new Queue<Waypoint>();
    Stack<Waypoint> pathStack = new Stack<Waypoint>();
    bool isRunning = true;

    Waypoint searchCenter;


    public Stack<Waypoint> GetPath()
    {
        LoadBlocks();
        ColorStartingAndEndingWaypoints();
        BreadthFirstSearch();
        CreatePath();
        return pathStack;
    }

    private void CreatePath()
    {
        Waypoint pivot = endingWaypoint;
        while (pivot != null)
        {
            pathStack.Push(pivot);
            pivot = pivot.exploredFrom;
        }
        
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startingWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
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
            if (grid.ContainsKey(neighbourPos))
            {
                QueueNewNeighbours(neighbourPos);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourPos)
    {
        Waypoint neighbour = grid[neighbourPos];

        if(!neighbour.isExplored && !queue.Contains(neighbour))
        {
            queue.Enqueue(neighbour);
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
    }
}
