using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvlManager : MonoBehaviour
{
    [SerializeField] private Button marketButton;
    [SerializeField] private Text MoneyText;
    private float money;
    
    void Start()
    {
        checkMoney();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void checkMoney()
    {
        if (!PlayerPrefs.HasKey("Money"))
        {
            money = 0;
            PlayerPrefs.SetFloat("Money",0);
        }
        else
        {
            money = PlayerPrefs.GetFloat("Money");
        }

        MoneyText.text = money.ToString();
    }

    
}
