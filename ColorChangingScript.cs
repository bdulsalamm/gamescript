using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class ColorChangingScript : MonoBehaviour
{
    
    public GameObject browser;

    private int clickCount = 0;
    private Color baseColor; 
    private Color targetReddishColor = new Color(0.5f, 0.0f, 0.0f, 0.2f);
    private int maxClickCount = 6; 

    private Material material; 

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material;

            baseColor = material.color;
        }
        else
        {
            // Debug.LogError("The attached game object doesn't have a Renderer component.");
        }
    }
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (browser == getClickedObject(out RaycastHit hit))
            {
                HandleMouseClick(true);
                // Debug.Log("Left-click detected in Colorchanging");
                
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (browser == getClickedObject(out RaycastHit hit))
            {
                HandleMouseClick(false);
            }
        }
    }

    // void UpdateOpenApp()
    // {
    //     if (OpenApp != null)
    //     {
    //         // Assuming you have values for Cpu and Gpu, update the UI Texts
    //         Cpu.text = "CPU: " + CpuValue.ToString();
    //         Gpu.text = "GPU: " + GpuValue.ToString();
    //         // Replace gpuValue with your actual GPU value
    //     }
    // }
    GameObject getClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            if (!IsPointerOverUIObject())
            {
                target = hit.collider.gameObject;
            }
        }
        return target;
    }

private bool IsPointerOverUIObject()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }


void HandleMouseClick(bool increase)
    {
        if (increase)
        {
            clickCount = Mathf.Min(clickCount + 1, maxClickCount);

        }
        else
        {
            
            clickCount = Mathf.Max(clickCount - 1, 0);
        }
        float t = Mathf.Clamp01((float)clickCount / maxClickCount);

        Color targetColor = new Color(
            baseColor.r + t / 1 * (targetReddishColor.r - baseColor.r),
            baseColor.g + t / 1 * (targetReddishColor.g - baseColor.g),
            baseColor.b + t / 1 * (targetReddishColor.b - baseColor.b)
        );

        material.color = targetColor;
    }
}