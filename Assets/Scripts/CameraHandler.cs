using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public float dragSpeed = 10;
    public float zoomSpeed = 7;
    private Vector3 dragOrigin;

    void Update()
    {
        // Zoom
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        if(mouseWheel != 0)
        {
            Debug.Log(Camera.main.fieldOfView);
            float zoomValue = Camera.main.fieldOfView;
            if (mouseWheel > 0 && zoomValue > 10)
            {
                zoomValue = zoomValue - zoomSpeed;
            }
            else if (mouseWheel < 0 && zoomValue < 130)
            {
                zoomValue = zoomValue + zoomSpeed;
            }

            //Vector3 zoomV = new Vector3(0, 0, zoomValue);
            //transform.Translate(zoomV, Space.World);
            Camera.main.fieldOfView = zoomValue;
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
    }
}