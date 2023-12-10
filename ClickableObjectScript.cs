using UnityEngine;

public class ClickableObjectScript : MonoBehaviour
{
    public void OnLeftClick()
    {
        // Handle left-click logic for this object
        Debug.Log("Left-clicked on " + gameObject.name);
    }

    public void OnRightClick()
    {
        // Handle right-click logic for this object
        Debug.Log("Right-clicked on " + gameObject.name);
    }
}
