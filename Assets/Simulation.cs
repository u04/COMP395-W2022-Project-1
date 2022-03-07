using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class Simulation : MonoBehaviour
{
    Customer[] customerArray = new Customer[500];
    public GameObject myPrefab;
    public float timeScale = 0.7f;
    private float fixedDeltaTime;

    // Start is called before the first frame update
    void Start()
    {


        using (StreamReader sr = new StreamReader(@"Assets/Book1.txt"))
        {
            string line;
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
            //Debug.Log("Arrival Time: " + customerArray[i].ArrivalTime + "     " + "Service Time: " + customerArray[i].ServiceTime);
        }
        StartCoroutine(ExampleCoroutine());
    }


    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }


    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Time.timeScale = timeScale;
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
    }
    IEnumerator ExampleCoroutine()
    {
        var tf = new TaskFactory();
        for (int i = 0; i < 500; i++)
        {

            float arrivalTime = Convert.ToSingle(customerArray[i].ArrivalTime);
            float serviceTime = Convert.ToSingle(customerArray[i].ServiceTime);
            yield return new WaitForSeconds(arrivalTime);
            if (GameObject.Find("Capsule(Clone)"))
            {
                GameObject temp1 = Instantiate(myPrefab, new Vector3(0, 04, 0), Quaternion.identity);
                Destroy(temp1, serviceTime);
            }
            else 
            {
                GameObject temp1 = Instantiate(myPrefab, new Vector3(0, 04, 0), Quaternion.identity);
                Destroy(temp1, serviceTime);

            }

        }
    }
}


