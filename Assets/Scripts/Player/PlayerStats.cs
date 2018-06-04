using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    private int amountOfMoney;

    public PlayerStats()
    {
        amountOfMoney = 0;
    }

    public PlayerStats(int amountOfMoneyDefault)
    {
        amountOfMoney = amountOfMoneyDefault;
    }

    public int getAmountOfMoney()
    {
        return amountOfMoney;
    }

    public bool increaseAmountOfMoney(int add)
    {
        amountOfMoney += add;
        return true;
    }

    public bool decreaseAmountOfMoney(int dec)
    {
        if (amountOfMoney - dec < 0)
            return false;
        amountOfMoney -= dec;
        return true;
    }

}
