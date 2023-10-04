using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    public GameObject basketPrefab;
    public GameObject gameOver;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
        basketList = new List<GameObject>();
        for (int i = 0; i<numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleMissed()
    {
        // destroy falling apples
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGo in appleArray)
        {
            Destroy(tempGo);
        }

        // destroy a basket and get index of last basket in list
        int basketIndex = basketList.Count - 1;

        // reference to that basket GameObject
        GameObject basketGO = basketList[basketIndex];

        // remove basket from list and destroy gameObject
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        // restart game if no baskets left
        if (basketList.Count == 0)
        {
            Time.timeScale = 0f; // pause everything
            gameOver.SetActive(true);
            //SceneManager.LoadScene("SampleScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
