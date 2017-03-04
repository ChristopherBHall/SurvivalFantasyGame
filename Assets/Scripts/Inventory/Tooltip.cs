using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {

    public Vector2 offSet;


    public GameObject tooltipObject;
    public Image backgroundImage;
    public Text button1;
    public Text button2;

    private void Start()
    {
        //ToggleTooltip(false, Vector2.zero);
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ToggleTooltip(false, Vector2.zero);

        }
            
    }
    public void ToggleTooltip(bool enabled, Vector2 position)
    {
        if(enabled == true)
        {
            tooltipObject.SetActive(true);
            backgroundImage.enabled = true;
            button1.enabled = true;
            button2.enabled = true;
        }
        else if (enabled == false)
        {
            tooltipObject.SetActive(false);
            backgroundImage.enabled = false;
            button1.enabled = false;
            button2.enabled = false;
        }

        transform.position = position + offSet;
    }
}
