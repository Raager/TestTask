using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            EventManadger.FoodCollision(other);
        }
        else if (other.gameObject.CompareTag("Bascket"))
        {
            EventManadger.BasketCollision(other);
        }
    }
}
