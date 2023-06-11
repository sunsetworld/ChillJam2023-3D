using UnityEngine;

public class CarrieMovement : MonoBehaviour
{
    public CharacterController playerController;
    public Transform playerCam;
    public float playerSpeed = 10f;
    public float rotationSmoothTime = 0.1f;
    public float rotationSmoothVelocity;

    // Update is called once per frame
    void Update()
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
            
            transform.rotation = Quaternion.Euler(0f, newAngle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, newTargetAngle, 0f) * Vector3.forward;
            playerController.Move(moveDirection.normalized * (playerSpeed * Time.deltaTime));
        }
    }
}
