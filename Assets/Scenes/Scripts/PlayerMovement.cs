using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.8f;
    public float mouseSensitivity = 0.3f;

    private CharacterController controller;
    private Vector3 velocity;
    private float xRotation = 0f;
    private Camera cam;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Movimento
        var kb = Keyboard.current;
        float h = 0f, v = 0f;

        if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) h = 1f;
        if (kb.aKey.isPressed || kb.leftArrowKey.isPressed) h = -1f;
        if (kb.wKey.isPressed || kb.upArrowKey.isPressed) v = 1f;
        if (kb.sKey.isPressed || kb.downArrowKey.isPressed) v = -1f;

        Vector3 move = transform.right * h + transform.forward * v;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Rotação com mouse
        var mouse = Mouse.current;
        float mouseX = mouse.delta.x.ReadValue() * mouseSensitivity;
        float mouseY = mouse.delta.y.ReadValue() * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}