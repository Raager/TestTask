using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAll : MonoBehaviour
{
    public GameObject[] dieObj;
    void Start()
    {
        EventManadger.GameOver += Destroyer;
    }

    void Destroyer(GameObject other)
    {
        for( int i = 0; i < dieObj.Length; i++)
        {
            Destroy(dieObj[i]);
        }
    }

    private void OnDestroy()
    {
        EventManadger.GameOver -= Destroyer;
    }
}
