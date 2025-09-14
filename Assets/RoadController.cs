using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    [SerializeField]
    private RoadlinesController roadlines;
    private Vector3 vehicleVelocity = Vector3.zero;
    private float linesSpawnTimer = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        linesSpawnTimer += Time.deltaTime;
        if (linesSpawnTimer >= 2f)
        {
            Vector3 spawnPosition = new Vector3(-10, -3, 0);
            Instantiate(roadlines, spawnPosition, Quaternion.identity);
            linesSpawnTimer = 0f;
        }
        
        transform.Translate(new Vector3(vehicleVelocity.x * Time.deltaTime, 0, 0));
    }
}
