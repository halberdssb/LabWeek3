using UnityEngine;
using UnityEngine.Rendering;

public class Task2 : MonoBehaviour
{
    // Calculates wholesale costs and profits for books sold based on prices and discounts


    public float coverPrice; // price of the book for customers
    public int copiesSold; // how many copies were sold

    private float bookstoreDiscount = .4f; // discount bookstores get off of cover price
    private float firstCopyShippingCost = 3f; // shipping cost of first book
    private float additionalShippingCost = 0.75f; // shipping cost for additional copies


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Wholesale Cost: $" + CalculateWholesaleCost(copiesSold, coverPrice, bookstoreDiscount));
        Debug.Log("Profit: $" + CalculateProfitMargin(copiesSold, coverPrice, bookstoreDiscount));
    }

    // calculates total shipping cost
    private float CalculateTotalShippingCost(int copiesSold, float firstCopyShippingCost, float additionalShippingCost)
    {
        // declare float for totalCost
        float totalCost = 0;

        // return 0 if no copies were sold
        if (copiesSold == 0)
        {
            return totalCost;
        }
        // else, calculate cost knowing that copiesSold is at least 1 - only add first copy cost once
        else
        {
            totalCost = firstCopyShippingCost + ((copiesSold - 1) * additionalShippingCost);
        }

        // return cost
        return totalCost;
    }
    
    // calculates wholesale cost for bookstores
    private float CalculateWholesaleCost(int copiesSold, float coverPrice, float bookstoreDiscount)
    {
        // calculate cost based on copies sold and discount - use 1 - discount to get amount after discount
        float wholesaleCost = copiesSold * (coverPrice * (1 - 0.4f));

        // subtract shipping cost
        wholesaleCost += CalculateTotalShippingCost(copiesSold, firstCopyShippingCost, additionalShippingCost);

        // return cost
        return wholesaleCost;
    }


    // calculates profit margin
    private float CalculateProfitMargin(int copiesSold, float coverPrice, float bookstoreDiscount)
    {
        // return left after wholesale cost
        float totalRevenue = copiesSold * coverPrice;

        // subtract wholesale cost
        float totalProfit = totalRevenue - CalculateWholesaleCost(copiesSold, coverPrice, bookstoreDiscount);

        // return totalProfit
        return totalProfit;
    }
}
