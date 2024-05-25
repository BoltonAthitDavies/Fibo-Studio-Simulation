using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonPos : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 canonPos;
    public float xValue;
    public float yValue;
    public float zValue;
    public float zPos;
    void Start()
    {
        zPos = GlobalVariables.zPos;
        xValue = 2.35f;
        yValue = 2.0f;
        //zValue = -2.5f;
        zValue = -zPos * 10;
        canonPos = new Vector3(xValue, yValue, zValue);
        transform.position = canonPos;
        Debug.Log("z: " + zValue);
    }

}
