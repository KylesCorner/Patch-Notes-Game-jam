using UnityEngine;

public class Dial : MonoBehaviour
{
    public RectTransform needle;   // assign the RPM needle UI sprite
    public float minAngle = 0f;  // angle at 0 RPM
    public float maxAngle = 230f;   // angle at max RPM

    [HideInInspector]
    public float currentValue = 0f;  // updated by CarController
    [HideInInspector]
    public float maxValue;   // max engine RPM

    public Dial(float maxValue)
    {
        this.maxValue = maxValue;
    }

    public void UpdateValue(float value)
    {
        this.currentValue = value;
    }

    public void UpdateMax(float value)
    {
        this.maxValue = value;
    }
    

    void Update()
    {
        float angle = Mathf.Lerp(minAngle, maxAngle, currentValue / maxValue);
        needle.localRotation = Quaternion.Euler(0f, 0f, -angle);
    }
}
