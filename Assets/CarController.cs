using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    [Header("RPM Settings")]
    public RPMGauge rpmGauge;
    public float minRPM = 200f;
    public float maxRPM = 8000f;
    public float idleRPM = 500f;
    
    [Header("Steering Settings")]
    public SteeringWheel steeringWheel;
    public float turnSpeed = 250f;
    public float maxTurnAngle = 360f;

    [Header("Shifter Settings")]
    public ShiftKnob shiftKnob;
    
    private int currentGear = 0;
    
    [Header("Wheel / Gearbox")]
    public GearBox gearbox;
    
    private float currentRPM = 0f;
    private Vector3 currentSpeed;
    private bool clutchPressed = false;
    private bool accelerating = false;

    [HideInInspector] public Vector2 vehicleVelocity = Vector2.zero;
    

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

    private void Start()
    {
        //Gauge Setup
        rpmGauge.maxRPM = maxRPM;
    }

    private void Update()
    {
        //Steering Logic Handling
        steeringWheel.turnSpeed = turnSpeed;
        steeringWheel.maxTurnAngle = maxTurnAngle;
        
        //Shift Knob Logic Handling
        shiftKnob.clutch = clutchPressed;
        currentGear = shiftKnob.currentGear;
        
        //GearBox Logic
        gearbox.clutch = clutchPressed;
        gearbox.throttle = accelerating;
        gearbox.currentGear = currentGear;

        gearbox.minRPM = minRPM;
        gearbox.maxRPM = maxRPM;
        gearbox.idleRPM = idleRPM;
        currentRPM = gearbox.currentRPM;
        currentSpeed = gearbox.currentSpeed;
        Debug.Log($"Current speed: {currentSpeed} | Current RPM: {currentRPM} | Current Gear: {currentGear}");
        
        //RPM Logic Handling
        rpmGauge.currentRPM = currentRPM;
        float targetWheelRPM = 0f;
        if (accelerating)
        {
            if (clutchPressed)
            {
            }
            else
            {
            }
            
        }
        else
        {
        }

        
    }
}
