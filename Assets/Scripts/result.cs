using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class result : MonoBehaviour
{
    [SerializeField] GameObject shopmanager;
    [SerializeField] GameObject homemanager;
    [SerializeField] GameObject foodtxt;
    [SerializeField] GameObject hobbytxt;
    float food;
    float hobby;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       food = shopmanager.GetComponent<Shopmanager>().Food();
       hobby = homemanager.GetComponent<Homemanager>().Hobby();
       if(food >100)
        {
            food = 100;
        }
       if(hobby >100)
        {
            hobby = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foodtxt.GetComponent<TextMeshProUGUI>().text = food.ToString("F1");
        hobbytxt.GetComponent<TextMeshProUGUI>().text = hobby.ToString("F1");
        if(food == 100)
        {
            homemanager.GetComponent<Homemanager>().SetMoney(2000);
        }
        else if(food >= 90)
        {
            homemanager.GetComponent<Homemanager>().SetMoney(1600);
        }
        else if(food >= 70)
        {
            homemanager.GetComponent<Homemanager>().SetMoney(1400);
        }
        else if(food >= 50)
        {
            homemanager.GetComponent<Homemanager>().SetMoney(1000);
        }
        else if(food>= 30)
        {
            homemanager.GetComponent<Homemanager>().SetMoney(800);
        }
        else if(food >= 10)
        {
            homemanager.GetComponent<Homemanager>().SetMoney(500);
        }
        else
        {
            homemanager.GetComponent<Homemanager>().SetMoney(0);
        }

        if (hobby == 100)
        {
            homemanager.GetComponent<Homemanager>().Money(2000);
        }
        else if (hobby >= 90)
        {
            homemanager.GetComponent<Homemanager>().Money(1600);
        }
        else if (hobby >= 70)
        {
            homemanager.GetComponent<Homemanager>().Money(1400);
        }
        else if (hobby >= 50)
        {
            homemanager.GetComponent<Homemanager>().Money(1000);
        }
        else if (hobby >= 30)
        {
            homemanager.GetComponent<Homemanager>().Money(800);
        }
        else if (hobby >= 10)
        {
            homemanager.GetComponent<Homemanager>().Money(500);
        }
        else
        {
            homemanager.GetComponent<Homemanager>().Money(0);
        }

        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            homemanager.GetComponent<Homemanager>().Flag(false);
            SceneManager.LoadScene("homescene");
        }
    }
}
