using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCube : MonoBehaviour {

    [SerializeField] Tower towerPrefab;

    bool isBuilt = false;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isBuilt)
            {
                Vector3 towerPos = new Vector3(transform.position.x, 0, transform.position.z);
                Instantiate(towerPrefab, towerPos, Quaternion.identity);
                isBuilt = true;
            }
        }
    }

}
