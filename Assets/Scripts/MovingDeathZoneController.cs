using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDeathZoneController : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 endPoint;
    public float speed = 1.0f;
    private float journeyLength;

    void Start()
    {
        journeyLength = Vector3.Distance(startPoint, endPoint);
    }

    void Update()
    {
        float pingPong = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(startPoint, endPoint, pingPong);
    }
}
