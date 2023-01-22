using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    public GameObject[] foods;
    Vector3 startPos = new Vector3(4.24f, 0.8f, 0.07f);
    void Start()
    {
        StartCoroutine(FoodSpawner());  
    }

    IEnumerator FoodSpawner()
    {
        while (true)
        {
            GameObject food = Instantiate(foods[Random.Range(0, foods.Length)], startPos, Quaternion.identity);
            food.name = food.name.Replace("(Clone)", "");
            yield return new WaitForSeconds(3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
