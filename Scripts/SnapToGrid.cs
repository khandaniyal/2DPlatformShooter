using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    public bool snapToGrid = true;
    public bool smartDrag = true;
    public bool isDraggable = true;
    public bool isDragged = true;
    private Vector2 initialPositionMouse;
    private Vector2 initialPositionObject;

    // Update is called once per frame
    void Update()
    {
        if (isDragged && !smartDrag)
        {
            transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            transform.position = initialPositionObject + (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - initialPositionMouse; 
        }

        if (snapToGrid)
        {
            transform.position = new Vector2(Mathf.RoundToInt(transform.position.x),
                Mathf.RoundToInt(transform.position.y));
        }
    }

    private void OnMouseOver() 
    {
        if (isDraggable && Input.GetMouseButtonDown(0))
        {
            isDragged = true;
        }
    }

    private void OnMouseUp()
    {
        isDragged = false;
    }
}
