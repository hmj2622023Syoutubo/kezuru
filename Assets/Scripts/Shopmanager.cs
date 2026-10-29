using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class Shopmanager : MonoBehaviour
{
    [SerializeField] GameObject homemanager;
    [SerializeField] GameObject text;
    [SerializeField] TextMeshProUGUI target;
    int money = 0;
    static float FoodLevel = 0;
    static float FoodMax;
    static float food;
    int feeling;
   
    public float Food()
    {
        food = FoodLevel/FoodMax * 10;
        return food;
    }
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        money = homemanager.GetComponent<Homemanager>().GetMoney();
        FoodMax = homemanager.GetComponent<Homemanager>().Foodmax();
        feeling = homemanager.GetComponent<Homemanager>().Feeling();
        if (FoodMax < 30)
        {
            target.text = "‚ ‚Ü‚è‚¨• ‚Í‚·‚¢‚Ä‚¢‚È‚¢";
        }
        else if(FoodMax < 70)
        {
            target.text = "‚Ü‚ ‚Ü‚ ‚¨• ‚Í‹ó‚¢‚Ä‚¢‚é";
        }
        else if(FoodMax < 150)
        {
            target.text = "‚©‚È‚è‚¨• ‚ª‚·‚¢‚Ä‚¢‚é";
        }
        else
        {
            target.text = "‚·‚²‚­‚¨• ‚ª‚·‚¢‚Ä‚¢‚é";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("watermelon") && money >= 1000)
                {
                    homemanager.GetComponent<Homemanager>().Money(-1000);
                    FoodLevel += 100;
                }
                else if (hit.collider.CompareTag("sandwich") && money >= 200)
                {
                    if (feeling == 1)
                    {
                        FoodLevel += 35;
                    }
                    else
                    {
                        FoodLevel += 20;
                    }
                        homemanager.GetComponent<Homemanager>().Money(-200);
                }
                else if (hit.collider.CompareTag("egg") && money >= 100)
                {
                    if (feeling == 2)
                    {
                        FoodLevel += 25;
                    }
                    else
                    {
                        FoodLevel += 10;
                    }
                        homemanager.GetComponent<Homemanager>().Money(-100);
                }
                else if (hit.collider.CompareTag("cookie") && money >= 150)
                {
                    if (feeling == 0)
                    {
                        FoodLevel += 30;
                    }
                    else
                    {
                        FoodLevel += 15;
                    }
                        homemanager.GetComponent<Homemanager>().Money(-150);
                }
                else if (hit.collider.CompareTag("croissant") && money >= 300)
                {
                    if (feeling == 1)
                    {
                        FoodLevel += 40;
                    }
                    else
                    {
                        FoodLevel += 30;
                    }
                        homemanager.GetComponent<Homemanager>().Money(-300);
                }
                else if (hit.collider.CompareTag("burger") && money >= 500)
                {
                    if (feeling == 1 && feeling == 2)
                    {
                        FoodLevel += 70;
                    }
                    else if(feeling == 3)
                    {
                        FoodLevel += 20;
                    }
                    else
                    {
                        FoodLevel += 50;
                    }
                        homemanager.GetComponent<Homemanager>().Money(-500);
                }
                else if (hit.collider.CompareTag("cake") && money >= 400)
                {
                    if (feeling == 0)
                    {
                        FoodLevel += 60;
                    }
                    else if(feeling == 3)
                    {
                        FoodLevel += 15;
                    }
                    else
                    {
                        FoodLevel += 40;
                    }
                        homemanager.GetComponent<Homemanager>().Money(-400);
                }
                money = homemanager.GetComponent<Homemanager>().GetMoney();
                Debug.Log("hit" + hit.collider.gameObject.name);
                Debug.Log(money);
            }
            else
            {
                Debug.Log("no hit");
            }
        }
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("homescene");
        }
        
        text.GetComponent<TextMeshProUGUI>().text = money.ToString("F1");
    }
}
