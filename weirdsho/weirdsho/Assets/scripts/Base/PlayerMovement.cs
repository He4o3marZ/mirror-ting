using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    public KeyCode Sprint;
    [SerializeField] float Speed;
    [SerializeField] float JumpForce;
    [SerializeField] float sprintmodifier;
    Camera cam;
    private float baseFOV;
    [SerializeField] float sprintFOVModifier;

    public LayerMask Ground;
    Rigidbody rb;
    public isGrounded isGrounded;

    private bool isJumping;

    void Start()
    {
        if (!isLocalPlayer)
        {
            this.enabled = false;
        }
        cam = GetComponentInChildren<Camera>();
        rb = GetComponent<Rigidbody>();
        baseFOV = cam.fieldOfView;
    }

    void FixedUpdate()
    {
        //MovementAxis
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //sprintChecks
        bool sprint = Input.GetKey(Sprint);
        bool isSprinting = sprint & isGrounded.Grounded && (vertical > 0);

        //Sprint
        float adjustSpeed = Speed;
        if (isSprinting)
        {
            adjustSpeed *= sprintmodifier;
            Debug.Log(adjustSpeed);
        }

        //Movement
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        Vector3 targetvelocity = transform.TransformDirection(direction) * 10 * adjustSpeed * Time.deltaTime;
        targetvelocity.y = rb.velocity.y;
        rb.velocity = targetvelocity;

        //FOV
        if (isSprinting)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, baseFOV * sprintFOVModifier, Time.deltaTime * 8f);
        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, baseFOV, Time.deltaTime * 8f);
        }

    }

    void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) & isGrounded.Grounded)
        {
            rb.AddForce(Vector3.up * 10 * JumpForce);
            //anim.SetTrigger("jump");
        }

    }
    void die()
    {
        //Death Stuff
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
        Debug.Log("shinu kozo");
    }
}
