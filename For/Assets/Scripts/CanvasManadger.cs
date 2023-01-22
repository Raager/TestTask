using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasManadger : MonoBehaviour
{
    public TextMeshProUGUI shouldToCollectTxt;
    public GameObject winPanel;
    public GameObject plusOneEffect;
    string foodToCollect;
    int collectingCount;

    void Start()
    {
        winPanel.SetActive(false);

        collectingCount = Random.Range(1, 6);
        if(collectingCount < 3)
        {
            foodToCollect = "carrot";
        }
        else if(collectingCount == 3)
        {
            foodToCollect = "banana";
        }
        else
        {
            foodToCollect = "grape";
        }
        shouldToCollectTxt.text = foodToCollect + " " + collectingCount.ToString();

        EventManadger.FoodInBasket += FoodInBin;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("MainLevel");
    }

    void FoodInBin(GameObject food)
    {
        if ( food.name == foodToCollect)
        {
            collectingCount--;
            Instantiate(plusOneEffect, new Vector3(0.5f, 2.01f, 3.86f), Quaternion.identity);
            if (collectingCount == 0)
            {
                winPanel.SetActive(true);
                shouldToCollectTxt.gameObject.SetActive(false);

                EventManadger.EndGame(food);
            }
            shouldToCollectTxt.text = foodToCollect + " " + collectingCount.ToString();
        }
    }

    private void OnDestroy()
    {
        EventManadger.FoodInBasket -= FoodInBin;
    }
}
