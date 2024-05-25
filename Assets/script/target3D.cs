using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target3D : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 200;
    void Start()
    {
        for (int x = 0; x < GlobalVariables.Rrotate; x += 1)
        {
            transform.Rotate(0, 0, 120);
        }
        for (int y = 0; y < GlobalVariables.Lrotate; y += 1)
        {
            transform.Rotate(0, 0, -120);
        }
        if (GlobalVariables.flip == true)
        {
            transform.Rotate(0, 180, 0);
        }
        //triangleHole.transform.Rotate(0, 0, -120);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
