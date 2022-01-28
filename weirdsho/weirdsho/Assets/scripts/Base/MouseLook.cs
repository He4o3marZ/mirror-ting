using UnityEngine;
using Mirror;

public class MouseLook : NetworkBehaviour
{
    Transform player;
    Camera cams;

    public float xSensitivity;
    public float ySensitivity;
    [SerializeField] float maxAngle;
    public Quaternion camCenter;
    public bool cursorLocked = true;

    void Start()
    {
        cams = GetComponentInChildren<Camera>();
        if (!isLocalPlayer)
        {
            this.enabled = false;
            cams.enabled = false;
        }
        player = GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        camCenter = cams.transform.localRotation;
    }
    void Update()
    {
        SetY();
        SetX();
    }


    void SetY()
    {
        float input = Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;
        Quaternion adj = Quaternion.AngleAxis(input, -Vector3.right);
        Quaternion delta = cams.transform.localRotation * adj;

        if (Quaternion.Angle(camCenter, delta) < maxAngle)
        {
            cams.transform.localRotation = delta;
        }
    }

    void SetX()
    {
        float input = Input.GetAxis("Mouse X") * xSensitivity * Time.deltaTime;
        Quaternion adj = Quaternion.AngleAxis(input, Vector3.up);
        Quaternion delta = player.localRotation * adj;
        player.localRotation = delta;
    }
}
