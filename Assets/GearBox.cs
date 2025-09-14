using UnityEngine;

[System.Serializable]
public class GearBox
{
    [HideInInspector]
    public int currentGear = 0; // 0 = neutral
    public bool clutch = false;   

    public float finalDrive = 3.5f;       // overall final drive ratio
    public float wheelRadius = 0.3f;      // meters
    public float[] gearRatios = {3.6f, 2.1f, 1.5f, 1.0f, 0.8f, 0.6f};

    public float wheelRPM = 0f; // rpm of wheels (from physics or input)
    
    // Called by shift knob
    public void SetGear(int gear)
    {
        currentGear = gear;
    }

    // Called by clutch input (0–1)
    public void SetClutch(bool value)
    {
        clutch = value;
    }

    // Engine RPM based on wheel RPM, clutch, and gear
    public float GetEngineRPM()
    {
        if (currentGear == 0 || clutch) 
            return 800f; // idle RPM when neutral or clutch disengaged

        int gearIndex = Mathf.Clamp(currentGear - 1, 0, gearRatios.Length - 1);
        return wheelRPM * gearRatios[gearIndex] * finalDrive;
    }

    // Speed in m/s
    // TODO: Need to output as a 2d vector where y is the speed
    public float GetSpeed()
    {
        return wheelRPM * 2f * Mathf.PI * wheelRadius / 60f; // wheel circumference
    }
}