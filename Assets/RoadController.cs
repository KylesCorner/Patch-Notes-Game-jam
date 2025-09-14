using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    [SerializeField]
    private RoadlinesController roadlines;
    public CarController car;
    private float _linesSpawnTimer = 0f;
    
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
        _linesSpawnTimer += Time.deltaTime;
        if (_linesSpawnTimer >= 2/ (car.vehicleVelocity.y/10 + 1))
        {
            Vector3 spawnPosition = new Vector3(-10, -4, 0);
            Instantiate(roadlines, spawnPosition, Quaternion.identity).Init(this, car);
            _linesSpawnTimer = 0f;
        }
        
        transform.Translate(new Vector3(car.vehicleVelocity.x * Time.deltaTime, 0, 0));
    }
}
