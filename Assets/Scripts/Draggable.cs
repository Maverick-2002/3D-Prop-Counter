using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Camera cam;
    private Rigidbody rb;
    private bool dragging = false;
    private float fixedX;
    private Vector3 offset;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        fixedX = transform.position.x;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            BeginDrag();

        if (Input.GetMouseButton(0) && dragging)
            Drag();

        if (Input.GetMouseButtonUp(0))
            EndDrag();
    }
    void BeginDrag()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject == gameObject)
        {
            dragging = true;
            rb.isKinematic = true;
            offset = transform.position - GetMouseWorldPosition();
        }
    }
    void Drag()
    {
        Vector3 target = GetMouseWorldPosition() + offset;
        target.x = fixedX;
        transform.position = target;
    }
    void EndDrag()
    {
        dragging = false;
        rb.isKinematic = false;
    }
    Vector3 GetMouseWorldPosition()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = cam.WorldToScreenPoint(transform.position).z;
        return cam.ScreenToWorldPoint(mouse);
    }
}
