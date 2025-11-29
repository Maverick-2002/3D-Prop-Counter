using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Camera cam;
    private Rigidbody rb;
    private bool dragging = false;
    private float yLevel;

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        yLevel = transform.position.y;
    }

    void Update()
    {
        HandleMouse();
    }

    void HandleMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    dragging = true;
                    rb.isKinematic = true;
                }
            }
        }

        if (Input.GetMouseButton(0) && dragging)
        {
            Plane plane = new Plane(Vector3.up, new Vector3(0, yLevel, 0));
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out float dist))
            {
                Vector3 pos = ray.GetPoint(dist);
                transform.position = pos;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            rb.isKinematic = false;
        }
    }
}
