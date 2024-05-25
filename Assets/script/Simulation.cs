using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour
{
    public Vector3 ballPos;
    public float time;
    public float speed;
    public float xValue;
    public float yValue;
    public float zValue;
    public float zPos;
    BaseHeights sim = new BaseHeights();
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        zPos = GlobalVariables.zPos;
        speed = GlobalVariables.speed;
        xValue = 2.65f;
        yValue = 3.7f;
        //zValue = -2.5f;
        zValue = -zPos * 10;

        // Create a Vector3 using the float values
        ballPos = new Vector3(2.65f, 3.7f, zValue);
        transform.position = ballPos;
        StartCoroutine(ballmovementLoop());
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    IEnumerator ballmovementLoop()
    {
        while (true)
        {
            for (float time = 0; time < 0.75 ; time += 0.01f)
            {
                Debug.Log("time: " + time);
                xValue = sim.ballmotion(speed, time).x + 2.65f;
                yValue = sim.ballmotion(speed, time).y;// + 3.7f;
                zValue = -zPos * 10;


                // Wait for the specified interval
                yield return new WaitForSeconds(0.01f);

                // Generate a new random position within the specified range
                Vector3 newPosition = new Vector3(
                    xValue,
                    yValue,
                    zValue
                );

                // Move the GameObject to the new position
                transform.position = newPosition;
                //time += 0.01f;
                // Print the new position to the console (optional)
                Debug.Log("z: " + zValue);
                Debug.Log("x: " + xValue);
                Debug.Log("y: " + yValue);
                Debug.Log("New Position: " + newPosition);
            }   
        }
    }
}
