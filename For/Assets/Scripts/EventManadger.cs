using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManadger : MonoBehaviour
{
    public delegate void GameControl(GameObject gj);
    public static event GameControl FoodChose;
    public static event GameControl FoodInBasket;
    public static event GameControl GameOver;

    public delegate void ColliderDetect(Collider other);
    public static event ColliderDetect FoodPicked;
    public static event ColliderDetect ThrowFood;

    public static void GoTo(GameObject gj)
    {
        FoodChose?.Invoke(gj);
    }
    public static void FoodCollision(Collider other)
    {
        FoodPicked?.Invoke(other);
    }
    public static void BasketCollision(Collider other)
    {
        ThrowFood?.Invoke(other);
    }

    public static void RecountFood(GameObject food)
    {
        FoodInBasket?.Invoke(food);
    }

    public static void EndGame(GameObject other)
    {
        GameOver?.Invoke(other);
    }
}
