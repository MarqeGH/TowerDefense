using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateSystem : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    
    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        SetCoordinates();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying)
        {
            SetCoordinates();
            SetTileNames();
        }
    }

    void SetTileNames()
    {
        transform.parent.name = coordinates.ToString();
    }

    void SetCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / (UnityEditor.EditorSnapSettings.move.x*2));
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / (UnityEditor.EditorSnapSettings.move.z*2));
        label.text = coordinates.x + "," + coordinates.y;
    }
}
