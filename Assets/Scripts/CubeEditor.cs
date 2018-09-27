using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {

    TextMesh TextMesh;
    Vector2Int gridPos;
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    // Update is called once per frame
    void Update ()
    {
        gridPos = waypoint.GetGridPos();
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(
            gridPos.x,
            0f,
            gridPos.y
        );
    }

    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();
        TextMesh = GetComponentInChildren<TextMesh>();
        string blockLabel = gridPos.x / gridSize + "," + gridPos.y / gridSize;
        TextMesh.text = blockLabel;
        gameObject.name = blockLabel;
    }
}
