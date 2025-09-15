using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class RoadController : MonoBehaviour
{
    public RoadlinesController roadlines;
    public CarController car;
    public VehicleController obsticleVehicle;
    private float _linesSpawnTimer = 0f;
    private float _carSpawnTimer = 0f;
    [SerializeField] public Sprite[] sprites;
    private float[] _lanes = { -16, -3, 12, -30 };
    private List<VehicleController> _vehicles;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (car == null)
        {
            car = FindFirstObjectByType<CarController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // lines
        _linesSpawnTimer += Time.deltaTime;
        if (_linesSpawnTimer >= 2 / (car.currentSpeed.y / 10 + 1))
        {
            Vector3 spawnPosition = new Vector3(-10, -4, 0);
            Instantiate(roadlines, spawnPosition, Quaternion.identity).Init(this, car);
            _linesSpawnTimer = 0f;
        }
        
        // obsticles
        _carSpawnTimer += Time.deltaTime;
        if (_carSpawnTimer >= 5f)
        {
            Instantiate(obsticleVehicle, new Vector3(_lanes[Random.Range(0, _lanes.Length)], -4), Quaternion.identity)
                .Init(this, car);
            _carSpawnTimer = 0f;
        }

        Debug.Log(car.currentSpeed);
        transform.Translate(new Vector3(car.currentSpeed.x * Time.deltaTime, 0, 0));
    }
}
