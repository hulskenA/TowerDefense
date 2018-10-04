using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 3;
    [SerializeField] Transform parentTransform;
    [SerializeField] Tower towerPrefab;

    Queue<Tower> towerQueue = new Queue<Tower>();

	public void AddTower(TowerCube baseWaypoint)
    {
        if (baseWaypoint.isBuilt)
            return;

        int placedTowers = towerQueue.Count;

        if (placedTowers < towerLimit)
            CreateNewTower(baseWaypoint);
        else
            MoveExistingTower(baseWaypoint);
    }

    private void CreateNewTower(TowerCube baseWaypoint)
    {
        Tower newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = parentTransform;
        baseWaypoint.isBuilt = true;
        newTower.baseWaypoint = baseWaypoint;
        towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower(TowerCube newBaseWaypoint)
    {
        Tower tower = towerQueue.Dequeue();
        tower.baseWaypoint.isBuilt = false;

        tower.transform.position = newBaseWaypoint.transform.position;
        newBaseWaypoint.isBuilt = true;
        tower.baseWaypoint = newBaseWaypoint;

        towerQueue.Enqueue(tower);
    }

}
