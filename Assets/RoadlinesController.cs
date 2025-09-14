using UnityEngine;

public class RoadlinesController : MonoBehaviour
{
    public RoadController roadController;
    private Vector3 vehicleVelocity = Vector3.down * 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (roadController == null)
        {
            roadController = FindFirstObjectByType<RoadController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(roadController.transform.position.x, transform.position.y + vehicleVelocity.y * Time.deltaTime, 0);

        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPos.y < -0.3f || viewportPos.y > 1.1f || viewportPos.x < -0.1f || viewportPos.x > 1.1f)
        {
            Destroy(gameObject);
        }
    }
}
