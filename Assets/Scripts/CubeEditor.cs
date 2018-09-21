using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour {

    [SerializeField][Range(1f, 20f)] float gridSize = 10f;

    TextMesh TextMesh;

    // Update is called once per frame
    void Update () {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        TextMesh = GetComponentInChildren<TextMesh>();
        string blockLabel = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        TextMesh.text = blockLabel;
        gameObject.name = blockLabel;
	}

}
