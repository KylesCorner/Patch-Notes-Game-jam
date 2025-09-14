using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    [Header("RPM Settings")]
    public RPMGauge rpmGauge;
    public float rpmIncreaseSpeed = 4000f;
    public float rpmDecreaseSpeed = 2000f;
    
    [Header("Steering Settings")]
    public SteeringWheel steeringWheel;
    public float turnSpeed = 250f;
    public float maxTurnAngle = 360f;

    [Header("Shifter Settings")]
    public ShiftKnob shiftKnob;
    
    private int currentGear = 0;
    
    private float currentRPM = 0f;
    private bool clutchPressed = false;
    private bool accelerating = false;
    

    private PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();

        inputActions.Player.Throttle.performed += ctx => accelerating = true;
        inputActions.Player.Throttle.canceled += ctx => accelerating = false;

        inputActions.Player.Clutch.performed += ctx => clutchPressed = true;
        inputActions.Player.Clutch.canceled += ctx => clutchPressed = false;
        
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    private void Update()
    {
        //Steering Logic Handling
        steeringWheel.turnSpeed = turnSpeed;
        steeringWheel.maxTurnAngle = maxTurnAngle;
        
        //Shift Knob Logic Handling
        currentGear = shiftKnob.currentGear;
        
        //RPM Logic Handling
        if (accelerating)
        {
            if (clutchPressed)
            {
                currentRPM += rpmIncreaseSpeed * Time.deltaTime;
            }
            else
            {
                currentRPM += rpmIncreaseSpeed * Time.deltaTime * (float)0.25;
            }
            
        }
        else
        {
            currentRPM -= rpmDecreaseSpeed * Time.deltaTime;
        }

        currentRPM = Mathf.Clamp(currentRPM, 0f, rpmGauge.maxRPM);
        rpmGauge.currentRPM = currentRPM;
        
    }
}