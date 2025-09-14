using UnityEngine;
using UnityEngine.Serialization;

public class GearBox : MonoBehaviour
{
    [HideInInspector] public int currentGear;
    [HideInInspector] public float minRPM;
    [HideInInspector] public float maxRPM;
    [HideInInspector] public float idleRPM;
    [HideInInspector] public float currentRPM;
    [HideInInspector] public Vector3 currentSpeed;
    [HideInInspector] public bool clutch;
    [HideInInspector] public bool throttle;
    private float speedPerRPM = 0.01f;
    
    public Gear[] gears;
    
    public bool IsOverRev()
    {
        return currentRPM > maxRPM;
    }

    public bool IsUnderRev()
    {
        return currentRPM < minRPM && currentGear != 0;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        currentSpeed = new Vector3(0f, 0f, 0f);
        currentRPM = 0f;
    }


    // Update is called once per frame
    void Update()
    {
        Gear gear = gears[currentGear];
        if (throttle)
        {
            // Increase speed and RPM according to this gear's function
            currentSpeed.y += gear.speedIncrease * Time.deltaTime;
            currentRPM += gear.rpmIncrease * Time.deltaTime;

            // Clamp to gear maxes
            currentSpeed.y = Mathf.Min(currentSpeed.y, gear.maxSpeed);
            currentRPM = Mathf.Min(currentRPM, maxRPM);


        }
        else
        {
            // decrease speed and RPM according to this gear's function
            if (currentSpeed.y > 0)
            {
                currentSpeed.y -= gear.speedIncrease * Time.deltaTime;
            }

            if (currentRPM > 0)
            {
                
                currentRPM -= gear.rpmIncrease * Time.deltaTime;
            }

            // Clamp to gear maxes
            currentSpeed.y = Mathf.Min(currentSpeed.y, gear.maxSpeed);
            currentRPM = Mathf.Min(currentRPM, maxRPM);
        }
    }
}
