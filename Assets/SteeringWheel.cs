using UnityEngine;
using UnityEngine.InputSystem;

public class SteeringWheel : MonoBehaviour
{
    [HideInInspector]
    public float turnSpeed = 250f;
    [HideInInspector]
    public float maxTurnAngle = 360f;

    public float currentAngle = 0f;
    private float steerInput = 0f;

    private PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Steer.performed += ctx => steerInput = ctx.ReadValue<float>();
        inputActions.Player.Steer.canceled += ctx => steerInput = 0f;
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    private void Update()
    {
        if (steerInput == 0f)
        {
            currentAngle = Mathf.Lerp(currentAngle, 0f, Time.deltaTime * 3f); // smooth return
        }
        
        currentAngle += steerInput * turnSpeed * Time.deltaTime;
        currentAngle = Mathf.Clamp(currentAngle, -maxTurnAngle, maxTurnAngle);

        transform.localRotation = Quaternion.Euler(0f, 0f, -currentAngle);
    }
}
