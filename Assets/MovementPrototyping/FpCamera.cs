using UnityEngine;
using UnityEngine.InputSystem;

namespace Frap
{
    public class FPCamera : MonoBehaviour
    {
        public Transform cam;
        public Transform player;
        public float mouseSensitivity = 1250f;
        public float maxXRot = 90f;
        public float minXRot = -90f;

        float xRot = 0f;
        float yRot = 0f;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            float fov = cam.GetComponent<Camera>().fieldOfView;
            Vector2 mouseDelta = Mouse.current.delta.ReadValue() * 0.1f;
            float mouseX = mouseDelta.x * (mouseSensitivity / (75 / fov)) * Time.deltaTime;
            float mouseY = mouseDelta.y * (mouseSensitivity / (75 / fov)) * Time.deltaTime;

            xRot -= mouseY;
            xRot = Mathf.Clamp(xRot, minXRot, maxXRot);

            yRot += mouseX;

            cam.localEulerAngles = new(xRot, 0, 0);
            player.localEulerAngles = new(0, yRot, 0);


        }
    }
}