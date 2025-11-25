using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public FloatingJoystick joystick;
    public float moveSpeed = 4f;
    public float rotationSpeed = 10f;
    public float gravity = -9.81f;
    public float jumpForce = 5f;

    [Header("References")]
    public Animator animator;
    public Transform lockTarget; // ← Boss hoặc enemy được lock
    private CharacterController controller;
    private PlayerHealth playerHealth;

    private Vector3 velocity;
    private bool isGrounded;
    private float turnSmoothVelocity;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (playerHealth.isDie && isGrounded) return;
        if (playerHealth.isStun || animator.GetCurrentAnimatorStateInfo(0).IsName("Gathering")) return;

        isGrounded = controller.isGrounded;
        animator.SetBool("IsGrounded", isGrounded);

        if (isGrounded && velocity.y < 0) velocity.y = -1f;

        float h, v;
#if UNITY_ANDROID || UNITY_IOS || UNITY_EDITOR
        h = joystick != null ? joystick.Horizontal : 0f;
        v = joystick != null ? joystick.Vertical : 0f;
#else
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
#endif
        animator.SetFloat("Horizontal", h, 0.1f, Time.deltaTime);
        animator.SetFloat("Vertical", v, 0.1f, Time.deltaTime);
        if (lockTarget == null)
        {
            Vector3 camForward = Camera.main.transform.forward;
            Vector3 camRight = Camera.main.transform.right;

            camForward.y = 0;
            camRight.y = 0;
            camForward.Normalize();
            camRight.Normalize();

            Vector3 moveDir = (camForward * v + camRight * h);
            if (moveDir.sqrMagnitude > 0.001f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(new Vector3(moveDir.x, 0, moveDir.z));
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
                controller.Move(moveDir * moveSpeed * Time.deltaTime);
            }
            //if (v > 0.1f)
            //{
            //    Quaternion targetRot = Quaternion.LookRotation(moveDir);
            //    transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * rotationSpeed);
            //    float targetYaw = transform.eulerAngles.y;
            //    Vector3 camEuler = Camera.main.transform.eulerAngles;
            //    camEuler.y = Mathf.LerpAngle(camEuler.y, targetYaw, Time.deltaTime * rotationSpeed); // Tốc độ xoay mượt
            //    Camera.main.transform.rotation = Quaternion.Euler(camEuler);
            //}
        }
        else
        {
            Vector3 lookDir = lockTarget.position - transform.position;
            lookDir.y = 0;
            if (lookDir.sqrMagnitude > 0.01f)
            {
                Quaternion lookRot = Quaternion.LookRotation(lookDir);
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, Time.deltaTime * rotationSpeed);
            }

            Vector3 moveDir = (transform.right * h + transform.forward * v);
            if (moveDir.sqrMagnitude > 1f) moveDir.Normalize();
            controller.Move(moveDir * moveSpeed * Time.deltaTime);
        }
#if !(UNITY_ANDROID || UNITY_IOS)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            animator.SetTrigger("Trigger_Jump");
        }
#endif
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    public void Jump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            animator.SetTrigger("Trigger_Jump");
        }
    }
}
