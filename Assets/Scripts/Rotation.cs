using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 lastMousePosition;

    public float rotationSpeed = 10f;

    void Update()
    {
        // mouse click and hold
        if (Input.GetMouseButtonDown(1))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }

        // mouse release
        if (Input.GetMouseButtonUp(1))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;

            float rotationX = delta.y * rotationSpeed * Time.deltaTime;
            float rotationY = -delta.x * rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, rotationY, Space.World);
            transform.Rotate(Vector3.right, rotationX, Space.World);

            lastMousePosition = Input.mousePosition;
        }
    }
}
