using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    Camera cam;
    HandControl hand;

    private void Start()
    {
        hand = gameObject.GetComponent<HandControl>();
        cam = Camera.main;
    }
    void Update()
    {
        if ( Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "Food")
                {
                    //hand.FoodChosen(hitInfo.collider.gameObject);
                    EventManadger.GoTo(hitInfo.collider.gameObject);
                }

            }
        }
    }
}
