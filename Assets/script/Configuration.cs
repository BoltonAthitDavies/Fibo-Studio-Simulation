using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Configuration : MonoBehaviour
{   
    public TMP_InputField yInput;
    public TMP_InputField zInput;
    public float yfloatValue;
    public float zfloatValue;

    //private BaseHeight obj = new BaseHeight();
    private BaseHeights obj = new BaseHeights();

    public TextMeshProUGUI stageOutput;
    public TextMeshProUGUI stageOutputshadow;

    public TextMeshProUGUI baseHeightOutput;
    public TextMeshProUGUI baseHeightOutputShadow;

    public TextMeshProUGUI zOutput;
    public TextMeshProUGUI zOutputShadow;
    
    void Start()
    {
        //InputField y = yInput.GetComponent<InputField>();
        //triangleHole.transform.Rotate(0, 0, 0);
        yInput.text = "0";
        zInput.text = "0";
        stageOutput.text = "OUTPUT : STAGE ";
        baseHeightOutput.text = "- Base Height :  m.";
        zOutput.text = "- Shooter's Z Position :  m.";

    }
    void Update()
    {
        stageOutputshadow.text = stageOutput.text;
        baseHeightOutputShadow.text = baseHeightOutput.text;
        zOutputShadow.text = zOutput.text;

    }

    public void reset()
    {
        yInput.text = "0";
        zInput.text = "0";
        stageOutput.text = "OUTPUT : STAGE ";
        baseHeightOutput.text = "- Base Height :  m.";
        zOutput.text = "- Shooter's Z Position :  m.";
        Debug.Log("z: ");
    }

    public void apply()
    {   
        if (float.TryParse(yInput.text, out yfloatValue) &&
            (float.TryParse(zInput.text, out zfloatValue)))
        {
            if (zfloatValue > 0.4 || zfloatValue < 0.1 || yfloatValue <= 0 || yfloatValue > 0.43)
            {
                stageOutput.text = "Out of range.";
                baseHeightOutput.text = "";
                zOutput.text = "";
                //Debug.LogError("Failed to convert string to float1.");
            }
            else
            {
                float initialspeed = obj.initialSpeed(yfloatValue);
                float puncherSpeed = obj.puncherSpeed(initialspeed);
                float baseheight = obj.baseheight(puncherSpeed);
                int stage = obj.stageNumber(baseheight);

                GlobalVariables.speed = initialspeed;
                GlobalVariables.zPos = zfloatValue;

                stageOutput.text = "OUTPUT : STAGE " + stage.ToString();
                baseHeightOutput.text = "- Base Height : " + baseheight.ToString() + "  m.";
                zOutput.text = "- Shooter's Z Position : " + zInput.text + " m.";
                Debug.Log("Converted value: " + yfloatValue);
                Debug.Log("Converted value: " + zfloatValue);
            }
        }

        else
        {
            stageOutput.text = "Invalid Input";
            baseHeightOutput.text = "";
            zOutput.text = "";
            //Debug.LogError("Failed to convert string to float2.");
        }
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GoTo3DScene(string sceneName)
    {
        if (GlobalVariables.speed != 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    //public void QuitApp()
    //{
        //Application.Quit();
        //Debug.Log("Application has quit.");
    //}
}
