using UnityEngine;

public class Task3 : MonoBehaviour
{
    // Calculates how a sum of money will be most efficiently broken down into different bills


    public int amountMoney; // amount of money to be broken up

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BreakDownIntoBills(amountMoney);
    }

    // breaks down passed in sum into specified bill amount
    private void BreakDownIntoBills(int amountMoney)
    {
        // 100
        if (amountMoney > 100)
        {
            amountMoney = GetNumberOfSpecifiedBill(amountMoney, 100);
        }

        // 50
        if (amountMoney > 50)
        {
            amountMoney = GetNumberOfSpecifiedBill(amountMoney, 50);
        }

        // 20
        if (amountMoney > 20)
        {
            amountMoney = GetNumberOfSpecifiedBill(amountMoney, 20);
        }

        // 10
        if (amountMoney > 10)
        {
            amountMoney = GetNumberOfSpecifiedBill(amountMoney, 10);
        }

        // 5
        if (amountMoney > 5)
        {
            amountMoney = GetNumberOfSpecifiedBill(amountMoney, 5);
        }

        // 1
        if (amountMoney > 1)
        {
            amountMoney = GetNumberOfSpecifiedBill(amountMoney, 1);
        }
    }

    private int GetNumberOfSpecifiedBill(int amountMoney, int billValue)
    {
        // debug
        Debug.Log("Number of $" + billValue + " Bills: " + (amountMoney / billValue));

        // return amount left
        return amountMoney %= billValue;
    }
}
