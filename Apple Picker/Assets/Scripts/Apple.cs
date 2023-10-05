using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public ConstantForce gravity;
    public int appleValue;
    public static float destroyApple = -20f;

    void Start()
    {
        if (this.gameObject.CompareTag("Apple"))
        {
            this.appleValue = 100;
        }

        if (this.gameObject.CompareTag("PoisonApple"))
        {
            this.appleValue = 0;
        }

        if (this.gameObject.CompareTag("GoldApple"))
        {
            this.appleValue = 500;
            gravity = gameObject.AddComponent<ConstantForce>();
            gravity.force = new Vector3(0.0f, -15f, 0.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < destroyApple)
        {
            Destroy(this.gameObject);

            if (this.gameObject.CompareTag("Apple")) {
                // reference to ApplePicker component of Main Camera
                ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
                // call public AppleMissed() method of apScript
                apScript.AppleMissed();
            }
        }
    }
}
