using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public float dragSpeed = 4;
    private Vector3 dragOrigin;

    void Update()
    {
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        if(mouseWheel != 0)
        {
            float zoomValue = 0f;
            if (mouseWheel > 0)
            {
                zoomValue = 1.5f;
            }
            else if (mouseWheel < 0)
            {
                zoomValue = -1.5f;
            }

            Vector3 zoomV = new Vector3(0, 0, zoomValue);
            transform.Translate(zoomV, Space.World);
            return;
        }


        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(dragOrigin - Input.mousePosition);
        Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);

        transform.Translate(move, Space.World);
    }
}