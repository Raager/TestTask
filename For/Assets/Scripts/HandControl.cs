using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControl : MonoBehaviour
{
    public int speedToFood;
    public int speedToBin;
    public Animator anim;
    public GameObject basketCenter;
    public GameObject bin;
    bool foodInHand;
    Rigidbody rb;
    GameObject hashForFood;
    Rigidbody foodRB;
    SpringJoint joint;


    private void Start()
    {
        anim.enabled = false;
        foodInHand = false;
        rb = GetComponent<Rigidbody>();
        EventManadger.FoodChose += FoodChosen;
        EventManadger.FoodPicked += FoodToBasket;
        EventManadger.ThrowFood += FoodThrow;
        EventManadger.GameOver += Ending;
    }

    void Ending(GameObject other)
    {
        anim.enabled = true;
    }

    void FoodThrow(Collider other)
    {
        StopAllCoroutines();
        hashForFood.transform.SetParent(other.gameObject.transform);
        joint.connectedBody = basketCenter.GetComponent<Rigidbody>();
        foodRB.isKinematic = false;
        foodRB.useGravity = true;
        foodRB = null;
        foodInHand = false;
        EventManadger.RecountFood(hashForFood);
    }

    void FoodToBasket(Collider food)
    {
        if(!food.GetComponent<FoodControl>().inBin)
        {
            StopCoroutine(HandGoingToFood(food.gameObject));
            food.transform.SetParent(transform);
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.constraints = RigidbodyConstraints.None;
            StartCoroutine(HandToBasket(food.gameObject));
            foodRB.useGravity = false;
            joint.connectedBody = rb;
            food.transform.localPosition = Vector3.zero;
        }

    }
    IEnumerator HandToBasket(GameObject food)
    {
        while(transform.position != basketCenter.transform.position)
        {
            //rb.AddForce((transform.position - basketCenter.transform.position) * -speedToBin);
            rb.velocity = (transform.position - basketCenter.transform.position) * -speedToBin;
            food.transform.localPosition = new Vector3(0, 0.2f, 0.15f);
            yield return new WaitForSeconds(0.02f);
        }
    }
    public void FoodChosen(GameObject food)
    {
        if (!foodInHand)
        {
            StartCoroutine(HandGoingToFood(food));
            hashForFood = food;
            foodInHand = true;
        }
    }

    IEnumerator HandGoingToFood(GameObject food)
    {
        foodRB = food.GetComponent<Rigidbody>();
        joint = food.AddComponent<SpringJoint>();
        joint.connectedBody = rb;
        joint.autoConfigureConnectedAnchor = false;
        while(transform.position != food.transform.position)
        {
            //gameObject.transform.LookAt(food.transform);
            //rb.AddForce((transform.position - food.transform.position) * -speedToFood);
            rb.velocity = (transform.position - food.transform.position) * -speedToFood;
            yield return new WaitForSeconds(0.02f);
            //Debug.Log("going");
            
        }
    }
    private void OnDestroy()
    {
        EventManadger.FoodChose -= FoodChosen;
        EventManadger.FoodPicked -= FoodToBasket;
        EventManadger.ThrowFood -= FoodThrow;
        EventManadger.GameOver -= Ending;
    }
}
