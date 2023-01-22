using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();

        EventManadger.GameOver += WinnerPosition;
    }

    void WinnerPosition(GameObject other)
    {
        StartCoroutine(CameraMove());
    }

    IEnumerator CameraMove()
    {
        while (cam.fieldOfView > 35)
        {
            cam.fieldOfView--;
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnDestroy()
    {
        EventManadger.GameOver -= WinnerPosition;
    }
}
