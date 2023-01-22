using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFoods : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Destroy(other.gameObject);
        }
    }
}
