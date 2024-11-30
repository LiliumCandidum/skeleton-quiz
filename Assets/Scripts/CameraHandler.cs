using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public float dragSpeed = 10;
    public float zoomSpeed = 7;
    public float rotationSpeed = 4;
    private Vector3 dragOrigin;

    void Update()
    {
        // Zoom
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        if(mouseWheel != 0)
        {
            float zoomValue = 0f;
            if (mouseWheel > 0)
            {
                zoomValue = zoomSpeed;
            }
            else if (mouseWheel < 0)
            {
                zoomValue = -zoomSpeed;
            }

            Vector3 zoomV = new Vector3(0, 0, zoomValue);
            transform.Translate(zoomV, Space.World);
            return;
        }

        // Save drag position when right or left mouse button is clicked
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        // Move
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(dragOrigin - Input.mousePosition);
            Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);

            transform.Translate(move, Space.Self);
            return;
        }
        // Rotate
        if(Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            Vector3 rotation = new Vector3(-mouseY, mouseX, 0) * rotationSpeed * Time.deltaTime;

            transform.Rotate(rotation, Space.Self);
            return;
        }
    }
}