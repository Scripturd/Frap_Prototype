using UnityEngine;

namespace Frap
{
    public class PlayerMovement : MonoBehaviour
    {
        private CharacterController Controller;

        public float walkSpeed = 12f;
        public float arialSpeed = 2f;
        public float gravity = -20f;
        public float jumpHeight = 3f;

        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;

        Vector3 velocity;
        bool isGrounded;

        // Start is called before the first frame update
        void Start()
        {
            Controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 moveDir = transform.right * x + transform.forward * z;

            // MOVE
            float speed = isGrounded ? walkSpeed : arialSpeed;
            Controller.Move(moveDir * speed * Time.deltaTime);

            // JUMP VELOCITY
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            // GRAVITY VELOCITY
            velocity.y += gravity * Time.deltaTime;

            // APPLY VELOCITY
            Controller.Move(velocity * Time.deltaTime);

        }
    }
}