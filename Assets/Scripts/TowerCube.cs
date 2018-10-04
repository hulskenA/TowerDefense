using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCube : MonoBehaviour {

    public bool isBuilt = false;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<TowerFactory>().AddTower(this);
        }
    }

}
