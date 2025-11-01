using UnityEngine;
using UnityEngine.InputSystem;

public class ARZoomRotateVuforia : MonoBehaviour
{
    private Vector3 originalScale;
    private float targetScale;
    private float baseScale;

    [Header("Zoom Settings")]
    public float zoomSpeed = 8f;
    public float minZoomFactor = 0.4f;
    public float maxZoomFactor = 3.5f;

    [Header("Rotate Settings")]
    public float rotationSpeed = 100f;
    private bool isDragging = false;
    private Vector2 lastMousePosition;

    void Start()
    {
        originalScale = transform.localScale;
        baseScale = originalScale.x;
        targetScale = baseScale;

        zoomSpeed = Mathf.Clamp(baseScale / 10f, 6f, 15f);
    }

    void Update()
    {
        if (Mouse.current == null) return;

        HandleZoom();
        HandleRotation();
    }

    void HandleZoom()
    {
        float scrollValue = Mouse.current.scroll.ReadValue().y;

        if (Mathf.Abs(scrollValue) > 0.01f)
        {
            float zoomChange = scrollValue * Time.deltaTime * zoomSpeed * 20f;
            targetScale = Mathf.Clamp(targetScale + zoomChange, baseScale * minZoomFactor, baseScale * maxZoomFactor);
        }

        float newScale = Mathf.Lerp(transform.localScale.x, targetScale, Time.deltaTime * zoomSpeed);
        transform.localScale = new Vector3(newScale, newScale, newScale);
    }

    void HandleRotation()
    {
        var mouse = Mouse.current;

        // Klik kiri untuk mulai drag
        if (mouse.leftButton.wasPressedThisFrame)
        {
            isDragging = true;
            lastMousePosition = mouse.position.ReadValue();
        }
        // Lepas klik
        if (mouse.leftButton.wasReleasedThisFrame)
        {
            isDragging = false;
        }

        // Kalau lagi drag, rotasi objek
        if (isDragging)
        {
            Vector2 currentMousePos = mouse.position.ReadValue();
            Vector2 delta = currentMousePos - lastMousePosition;

            float rotationY = -delta.x * rotationSpeed * Time.deltaTime;
            float rotationX = delta.y * rotationSpeed * Time.deltaTime;

            // Rotasi di sumbu Y dan X (bisa diubah sesuai kebutuhan)
            transform.Rotate(Vector3.up, rotationY, Space.World);
            transform.Rotate(Vector3.right, rotationX, Space.World);

            lastMousePosition = currentMousePos;
        }
    }
}
