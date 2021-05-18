using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Economy : MonoBehaviour
{
    private int money = 0;
    public int turretCost = 5;
    public Text moneyText;

    public void AddMoney()
    {
        money = money + 1;
        UpdateMoney();
    }

    public bool CanBuild()
    {
        if (money >= turretCost)
        {
            money = money - turretCost;
            UpdateMoney();
            return true;
        }
        return false;
    }

    private void UpdateMoney()
    {
        moneyText.text = "Peníze: " + money;
        //moneyText.text = money.ToString();
    }
}
