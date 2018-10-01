using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobilecontrolls : MonoBehaviour
{
    // Start is called before the first frame update
    public void onPress(float btn)
    {
        Debug.Log(btn + "pressed");
    }

    public void onRelease(float btn)
    {
        Debug.Log(btn + "released");
    }
}
