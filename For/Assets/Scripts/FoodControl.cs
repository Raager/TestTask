using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodControl : MonoBehaviour
{
    float speed = 2;
    bool theChosen;
    public bool inBin;
    Rigidbody rb;

    private void Start()
    {
        inBin = false;
        theChosen = false;
        rb = GetComponent<Rigidbody>();
        EventManadger.FoodPicked += CheckSelf;
        EventManadger.ThrowFood += LoseParants;
    }

    void CheckSelf(Collider other)
    {
        if(other.gameObject == gameObject)
        {
            theChosen = true;
        }
    }

    void LoseParants(Collider other)
    {
        //transform.SetParent(null);
        if(theChosen)
        {
            inBin = true;
            gameObject.tag = "Finish";
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!theChosen)
        {
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
        }
    }
    private void OnDestroy()
    {
        EventManadger.FoodPicked -= CheckSelf;
        EventManadger.ThrowFood -= LoseParants;
    }
}
