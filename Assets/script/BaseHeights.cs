using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct pointaxis
{
    public float x;
    public float y;
}

public static class GlobalVariables
{
    public static float speed;
    public static float zPos;
    public static int Rrotate = 0;
    public static int Lrotate = 0;
    public static bool flip;
}

public class BaseHeights
{
    private float tableHeight = 0.755f;
    private float mAll = 0.024f + 0.5f + 0.4f; // puncher mass + holder mass + ball mass (kg.)
    private float puncherMass = 0.5f; // Puncher mass (m.)
    private float h1 = 0.1367f; // Initial puncher Height (m.)
    private float g = 9.81f; // gravitational acceleration (m/s2)
    private float k = 1811.67f; // spring constant (N/m)
    private float x1 = 0.19f; // compressed spring length (m.)
    private float xAll = 0.3f; // spring length
    public pointaxis ball; // ball axis

    public float initialSpeed(float yinput)
    {
        //float tableHeight = 0.755f;
        return Mathf.Sqrt(3924.0f / (233.0f - (100.0f * (yinput + tableHeight))));
    }

    public pointaxis ballmotion(float initspeed, float t)
    {
        //pointaxis ball;
        ball.x = initspeed * (Mathf.Sqrt(2.0f) / 2.0f) * t * 10.0f ;
        ball.y = (((initspeed * (Mathf.Sqrt(2.0f) / 2.0f)) * t) - ((1.0f / 2.0f) * 9.81f * Mathf.Pow(t, 2.0f)) + 0.33f) * 10.0f ;
        return ball;

    }

    public float puncherSpeed(float initspeed)
    {
        //float mAll = 0.024f + 0.5f + 0.4f;
        return mAll * initspeed * 2.0f;
    }

    public float baseheight(float pSpeed)
    {
        //float puncherMass = 0.5f; // Puncher mass (m.)
        //float h1 = 0.1367f; // Initial puncher Height (m.)
        //float g = 9.81f; // gravitational acceleration (m/s2)
        //float k = 1811.67f; // spring constant
        //float x1 = 0.19f; // compressed spring length (m.)
        //float xAll = 0.3f;
        float a = 2 * k;
        float b = (-2.0f * Mathf.Sqrt(2.0f) * k * xAll) - (0.235736f * k) + (2.0f * puncherMass * g);
        float c = (-2.0f * puncherMass * g * h1) - (k * Mathf.Pow(x1, 2)) + (k * Mathf.Pow(xAll, 2)) + (0.16669f * k * xAll) + (0.006946f * k) + (puncherMass * Mathf.Pow(pSpeed, 2));
        float baseHieght = (-b - Mathf.Sqrt(Mathf.Pow(b, 2) - 4 * a * c)) / (2 * a);
        return baseHieght;
    }

    public int stageNumber(float bHeight)
    {
        if(0.19259f < bHeight && bHeight < 0.19712)
        {
            return 1;
        }
        else if(0.19713f < bHeight && bHeight < 0.20257)
        {
            return 2;
        }
        else if (0.20258f < bHeight && bHeight < 0.20932)
        {
            return 3;
        }
        else if (0.20933f < bHeight && bHeight < 0.21807)
        {
            return 4;
        }
        else if (0.21808f < bHeight && bHeight < 0.23104f)
        {
            return 5;
        }
        else
        {
            return 0;
        }

    }
}
