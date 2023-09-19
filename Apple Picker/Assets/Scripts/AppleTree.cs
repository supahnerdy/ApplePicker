using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject applePrefab;
    public float boundary;
    public float dropRate;
    public float initVel = 1f;
    public float changeRate;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        // epsilon check for Doubles
        if ((pos.x - 0.001 <= boundary && boundary <= pos.x + 0.001) || // hits the right side
            (pos.x - 0.001 <= -boundary && -boundary <= pos.x + 0.001)) // hits the left side
        {
            initVel *= -1; // to change distance
        }

        // pos.x += initVel is 60 units per second, (variable data), irregular movements
        pos.x += initVel * Time.deltaTime; // instead of by frame, 1ups, (smoothed)

        if (pos.x >= boundary)
        {
            pos.x = boundary;
        }

        if (pos.x <= -boundary)
        {
            pos.x = -boundary;
        }

        transform.position = pos;



    }
}
