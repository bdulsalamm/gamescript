using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ClickHandlingScript : MonoBehaviour
{
    public TextMeshProUGUI CpuText;
    public TextMeshProUGUI GpuText;

    private float cpuValue = 20.0f;
    private float gpuValue = 20.0f;

    void Update()
{
    UpdateCpuAndGpuText();

    if (Input.GetMouseButtonDown(0))
    {
        GameObject clickedObject = GetClickedObject();

        if (clickedObject != null)
        {
            ClickableObjectScript clickableScript = clickedObject.GetComponent<ClickableObjectScript>();

            if (clickableScript != null)
            {
                if (cpuValue < 100.0f && gpuValue < 100.0f)
                {
                    cpuValue += 20.0f;
                    gpuValue += 15.0f;

                    clickableScript.OnLeftClick();
                }
            }
        }
    }
    else if (Input.GetMouseButtonDown(1))
    {
        ReverseValues();
    }
}


    void UpdateCpuAndGpuText()
    {
        CpuText.text = "CPU: " + cpuValue.ToString();
        GpuText.text = "GPU: " + gpuValue.ToString();
    }

    void ReverseValues()
    {
        cpuValue = Mathf.Max(cpuValue - 20.0f, 20.0f);
        gpuValue = Mathf.Max(gpuValue - 15.0f, 20.0f);

    }

    GameObject GetClickedObject()
    {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo))
        {
            return hitInfo.collider.gameObject;
        }

        return null;
    }
}
