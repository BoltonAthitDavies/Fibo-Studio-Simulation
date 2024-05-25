using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float rotationSpeed = 200;
    //public int x = GlobalVariables.rotatex;
    //public int y = GlobalVariables.rotatey;
    //public int z = GlobalVariables.rotatez;
    public Toggle toggle;
    public GameObject triangleHole;
  
    void Start()
    {
        //triangleHole.transform.Rotate(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void flip()
    {
        if (toggle.isOn)
        {
            GlobalVariables.flip = true;
            Debug.Log("State is true. Rotating triangleHole by 180 degrees.");
            //GlobalVariables.rotatey = 180;
            triangleHole.transform.Rotate(0, 180, 0);
        }
        else
        {
            GlobalVariables.flip = false;
            Debug.Log("State is false. Resetting triangleHole rotation.");
            //GlobalVariables.rotatey = 0;
            triangleHole.transform.Rotate(0, -180, 0);
        }
    }
    public void rightRotate()
    {
        GlobalVariables.Rrotate += 1;
        triangleHole.transform.Rotate(0, 0, 120);

    }
    public void leftRotate()
    {
        GlobalVariables.Lrotate += 1;
        triangleHole.transform.Rotate(0, 0, -120);
    }
}
