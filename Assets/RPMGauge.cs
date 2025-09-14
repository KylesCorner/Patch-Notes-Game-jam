using UnityEngine;
using UnityEngine.UI;

public class RPMGauge : MonoBehaviour
{
    public RectTransform needle;   // assign the RPM needle UI sprite
    private float minAngle = 0f;  // angle at 0 RPM
    private float maxAngle = 230f;   // angle at max RPM

    [HideInInspector]
    public float currentRPM = 0f;  // updated by CarController
    [HideInInspector]
    public float maxRPM;   // max engine RPM

    void Update()
    {
        float angle = Mathf.Lerp(minAngle, maxAngle, currentRPM / maxRPM);
        needle.localRotation = Quaternion.Euler(0f, 0f, -angle);
    }
}