using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 lastMousePosition;

    public float rotationSpeed = 10f;  // Adjust the speed of rotation

    void Update()
    {
        // Detect mouse click and hold
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }

        // Detect mouse release
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Rotate object when dragging
        if (isDragging)
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;

            // Rotation on the X-axis (Vertical mouse drag)
            float rotationX = delta.y * rotationSpeed * Time.deltaTime;

            // Rotation on the Y-axis (Horizontal mouse drag)
            float rotationY = -delta.x * rotationSpeed * Time.deltaTime;

            // Apply rotation
            transform.Rotate(Vector3.up, rotationY, Space.World);
            transform.Rotate(Vector3.right, rotationX, Space.World);

            // Update last mouse position
            lastMousePosition = Input.mousePosition;
        }
    }
}
