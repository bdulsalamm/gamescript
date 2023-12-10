using UnityEngine;

public class FlexibleCameraControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 0.5f; 
    public float fastRotationSpeed = 1f; 
    public float panSpeed = 0.5f; 
    public float zoomSpeed = 5f;

    private bool isRotating = false;
    private bool isPanning = false;
    private Vector3 lastMousePosition;
    private Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.rotation;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) 
        {
            isRotating = true;
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }

        if (Input.GetMouseButtonDown(2)) 
        {
            isPanning = true;
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(2))
        {
            isPanning = false;
        }

        if (isRotating || isPanning)
        {
            float currentRotationSpeed = Input.GetMouseButton(0) ? fastRotationSpeed : rotationSpeed;
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;

            if (isRotating)
            {
                transform.Rotate(Vector3.up, mouseDelta.x * currentRotationSpeed * Time.deltaTime);
                transform.Rotate(Vector3.left, mouseDelta.y * currentRotationSpeed * Time.deltaTime);
            }

            if (isPanning)
            {
                Vector3 panDelta = new Vector3(-mouseDelta.x, -mouseDelta.y, 0) * panSpeed * Time.deltaTime;
                transform.Translate(panDelta, Space.Self);
            }

            lastMousePosition = Input.mousePosition;
        }

        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(Vector3.forward * scrollWheel * zoomSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.P))
        {
            Vector3 originalEulerAngles = originalRotation.eulerAngles;
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        }
    }
}
