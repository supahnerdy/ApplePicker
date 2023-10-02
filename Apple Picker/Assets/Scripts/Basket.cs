using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    public Apple apple;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter"); // find GameObj ScoreCounter in Scene
        scoreCounter = scoreGO.GetComponent<ScoreCounter>(); // get ScoreCounter component of scoreGO
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition; // get current pos of mouse from input
        mousePos2D.z = -Camera.main.transform.position.z; // z pos sets how far to push mouse into 3D

        // convert from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); 

        // move x pos of basket to x pos of Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }


    void OnCollisionEnter(Collision coll)
    {

        // find out what hit basket
        GameObject collidedWith = coll.gameObject;

        // destroy any apple that hits it
        if (collidedWith.CompareTag("Apple") || collidedWith.CompareTag("GoldApple") || collidedWith.CompareTag("PoisonApple"))
        {
            Destroy(collidedWith);
            if (collidedWith.CompareTag("PoisonApple"))
            {
                // reference to ApplePicker component of Main Camera
                ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
                // call public AppleMissed() method of apScript
                apScript.AppleMissed();
            }
        }

        // find point value of apple
        int applePoint = collidedWith.gameObject.GetComponent<Apple>().appleValue;

        // increment point value of apple
        scoreCounter.score += applePoint;
        HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
    }
}
