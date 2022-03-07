using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreadWithState : MonoBehaviour
{

    public GameObject myPrefab;


    // State information used in the task.
    private float ServiceTime;
    //private GameObject MyPrefab;

    // The constructor obtains the state information.
    public ThreadWithState(float serviceTime)
    {
        ServiceTime = serviceTime;

    }

    // The thread procedure performs the task, such as formatting
    // and printing a document.
    public void ThreadProc()
    {
        Debug.Log("from thread");
        //ExampleCoroutine();
    }
    IEnumerator ExampleCoroutine()
    {
        GameObject temp1 = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(ServiceTime);
        Destroy(temp1);
        Debug.Log("from thread");
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
