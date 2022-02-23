using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LogToConsole : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Customer[] customerArray = new Customer[500];

        using (StreamReader sr = new StreamReader(@"Assets/Book1.txt"))
        {
            string line;
            // Read and display lines from the file until the end of
            // the file is reached.
            int counter = 0;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains("Customer"))
                { //do nothing to skip
                }
                else
                {
                    string[] subs = line.Split('\u0009');
                    Customer customer = new Customer();
                    customer.CreateCustomer(Convert.ToInt32(subs[0]), Convert.ToDouble(subs[1]), Convert.ToDouble(subs[2]));
                    customerArray[counter] = customer;
                    //Debug.Log(counter);
                    counter++;

                }
            }
        }
        for (int i = 0; i < 500; i++)
        {
            Debug.Log("Arrival Time: " + customerArray[i].ArrivalTime + "     " + "Service Time: " + customerArray[i].ServiceTime);
        }
        

    }

    // Update is called once per frame
    void Update()
    {

    }
}
