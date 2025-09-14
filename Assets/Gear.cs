using UnityEngine;

[System.Serializable]
public class Gear :  MonoBehaviour
{
    public string name = "Gear";
    public float speedIncrease = 5f;  // how much speed increases per tick
    public float rpmIncrease = 200f;  // how much RPM increases per tick
    public float maxSpeed = 20f;      // max speed allowed in this gear
    public float minRPM = 4000f;      // min RPM allowed in this gear
}