using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject applePrefab;
    public GameObject goldenPrefab;
    public GameObject poisonPrefab;
    public float boundary;
    public float dropRate; // appleDropDelay
    public float initVel = 10f;
    public float changeRate = 0.02f; // changeDirChance
    public float goldenRate = 0.01f;
    public float poisonRate = 0.005f;

    void Start()
    {
        Invoke("DropApple", 2f);

    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", dropRate);
    }

    void GoldenApple()
    {
        GameObject golden = Instantiate<GameObject>(goldenPrefab);
        golden.transform.position = transform.position;
    }

    void PoisonApple()
    {
        GameObject poison = Instantiate<GameObject>(poisonPrefab);
        poison.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        // epsilon check for Doubles
        if ((pos.x - 0.0001 <= boundary && boundary <= pos.x + 0.0001) || // hits the right side
            (pos.x - 0.0001 <= -boundary && -boundary <= pos.x + 0.0001)) // hits the left side
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

    void FixedUpdate() // exactly 50 times per second
    {
        
        if (Random.value < changeRate) // direction changes at random
        {
            initVel *= -1;
        }

        if (Random.value < goldenRate)
        {
            GoldenApple(); // randomly generate golden apple
        } 

        if (Random.value < poisonRate)
        {
            PoisonApple(); // randomly generate golden apple
        }
    }
}
