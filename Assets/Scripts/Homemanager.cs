using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Homemanager : MonoBehaviour
{
    [SerializeField] GameObject shopmanager;
    [SerializeField] GameObject text;
    [SerializeField] TextMeshProUGUI target;
    static float FoodMax;
    static float HobbyMax;
    static int money = 3000;
    static bool flag = false;
    static int feeling;
    
    public float Foodmax()
    {
        return FoodMax;
    }
    public void Money(int Money)
    {
        money += Money;
    }
    public void SetMoney(int Money)
    {
        money = Money;
    }
    public int GetMoney()
    {
        return money;
    }
    public float Hobby()
    {
        return money/HobbyMax * 100;
    }
    public void Flag(bool Flag)
    {
        flag = Flag;
    }
    public int Feeling()
    {
        return feeling;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (flag == false)
        {
            FoodMax = Random.Range(10, 200);
            HobbyMax = Random.Range(100,3000);
            feeling = Random.Range(0, 4);
        }
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (feeling == 0)
        {
            target.text = "甘いものが食べたい";
        }
        else if(feeling == 1)
        {
            target.text = "パンが食べたい";
        }
        else if(feeling == 2)
        {
            target.text = "たんぱく質をとりたい";
        }
        else if(feeling == 3)
        {
            target.text = "太りたくない";
        }
        else
        {
            target.text = "特にこれが食べたいというものはない";
        }
        text.GetComponent<TextMeshProUGUI>().text = money.ToString("F1");
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("shopscene");
        }
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("resultscene");
        }
    }
}
