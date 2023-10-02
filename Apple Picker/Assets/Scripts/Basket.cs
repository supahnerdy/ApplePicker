using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
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
        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
        }

        scoreCounter.score += 100;
        HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
    }
}
