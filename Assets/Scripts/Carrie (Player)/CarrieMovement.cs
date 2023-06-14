using Cinemachine;
using UnityEngine;

public class CarrieMovement : MonoBehaviour
{
    [SerializeField] private bool canMove = true;
    [SerializeField] private bool canRotate = true;
    public CharacterController playerController;
    public Transform playerCam;
    public float playerSpeed = 10f;
    public float rotationSmoothTime = 0.1f;
    public float rotationSmoothVelocity;

    private CinemachineFreeLook _cinemachineFreeLook;
    [SerializeField] private float camXMultiplier = 1f;
    [SerializeField] private float camYMultiplier = 1f;

    private float _camXSpeed;
    private float _camYSpeed;

    private void Start()
    {
        _cinemachineFreeLook = FindObjectOfType<CinemachineFreeLook>();
        GetCameraSpeed();
    }

    private void GetCameraSpeed()
    {
        _camXSpeed = _cinemachineFreeLook.m_XAxis.m_MaxSpeed * camXMultiplier;
        _camYSpeed = _cinemachineFreeLook.m_YAxis.m_MaxSpeed * camYMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 newDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        if (newDirection.magnitude >= 0.1f)
        {
            float newTargetAngle = Mathf.Atan2(newDirection.x, newDirection.z) * Mathf.Rad2Deg + playerCam.eulerAngles.y;
            float newAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                newTargetAngle,
                ref rotationSmoothVelocity,
                rotationSmoothTime);

            if (canRotate)
            {
                transform.rotation = Quaternion.Euler(0f, newAngle, 0f);
            }
            if (canMove)
            {
                Vector3 moveDirection = Quaternion.Euler(0f, newTargetAngle, 0f) * Vector3.forward;
                playerController.Move(moveDirection.normalized * (playerSpeed * Time.deltaTime));
            }
        }

        SetCameraRotationSpeed();
    }

    private void SetCameraRotationSpeed()
    {
        if (Input.GetKey(KeyCode.Mouse1) && canRotate)
        {
            _cinemachineFreeLook.m_XAxis.m_MaxSpeed = _camXSpeed;
            _cinemachineFreeLook.m_YAxis.m_MaxSpeed = _camYSpeed;
        }
        else
        {
            _cinemachineFreeLook.m_XAxis.m_MaxSpeed = 0;
            _cinemachineFreeLook.m_YAxis.m_MaxSpeed = 0;
        }
    }

    public void EnablePlayerMovement()
    {
        canMove = true;
    }

    public void DisablePlayerMovement()
    {
        canMove = false;
    }
}
