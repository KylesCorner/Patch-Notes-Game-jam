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
            _roadController.transform.position.x, 
            transform.position.y - _carController.vehicleVelocity.y / 2 * Time.deltaTime,
            0
        );
        
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPos.y < -0.3f || viewportPos.y > 1.1f || viewportPos.x < -0.1f || viewportPos.x > 1.1f)
        {
            Destroy(gameObject);
        }
    }

    public void Init(RoadController roadController, CarController carController, Sprite sprite)
    {
        this._roadController = roadController;
        this._carController = carController;
        this.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
