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
    
    public Gear[] gears;
    
    public bool IsOverRev()
    {
        return currentRPM > maxRPM;
    }

    public bool IsUnderRev()
    {
        return currentRPM < minRPM && (currentGear != 0);
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
        if (clutch)
        {
            currentGear = 0;
        }
        Gear gear = gears[currentGear];
        if (throttle)
        {
            currentSpeed.y += gear.speedIncrease * Time.deltaTime;
            if (!IsOverRev())
            {
                currentRPM += gear.rpmIncrease * Time.deltaTime;
            }
        }
        else
        {
            currentSpeed.y -= gear.speedDecrease * Time.deltaTime;
            if (!IsUnderRev())
            {
                currentRPM -= gear.rpmDecrease* Time.deltaTime;
                if (currentGear == 0 && currentRPM < idleRPM)
                {
                   currentRPM = idleRPM; 
                }
            }
        }
        // Clamp to gear maxes
        if (currentSpeed.y < 0)
        {
            currentSpeed.y = 0;
        }
        currentSpeed.y = Mathf.Min(currentSpeed.y, gear.maxSpeed);
        currentRPM = Mathf.Min(currentRPM, maxRPM);
    }
}
