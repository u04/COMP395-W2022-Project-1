using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer
{
    public int CustomerNumber { get; set; }
    public double ArrivalTime { get; set; }
    public double ServiceTime { get; set; }
    public void CreateCustomer(int customerNumber, double arrivalTime, double serviceTime)
    {
        CustomerNumber = customerNumber;
        ArrivalTime = arrivalTime;
        ServiceTime = serviceTime;
    }

}
