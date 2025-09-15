using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    private RoadController _roadController;
    private CarController _carController;
    private Sprite _sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            _roadController.transform.position.x + transform.position.x, 
            transform.position.y - _carController.currentSpeed.y / 100 * Time.deltaTime,
            0
        ); 
        
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPos.y < -1f || viewportPos.y > 1.1f)
        {
            Destroy(gameObject);
        }
    }

    public void Init(RoadController roadController, CarController carController)
    {
        this._roadController = roadController;
        this._carController = carController;
    }
}
