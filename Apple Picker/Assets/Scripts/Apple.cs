using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float destroyApple = -20f;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < destroyApple)
        {
            Destroy(this.gameObject);

            // reference to ApplePicker component of Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            // call public AppleMissed() method of apScript
            apScript.AppleMissed();
        }
    }
}
