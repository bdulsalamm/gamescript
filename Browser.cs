using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class Browser : MonoBehaviour
{
    public GameObject tabPrefab;
    public Transform tabsContainer;

    private int tabCount = 0;

    public void OpenTab(string tabName)
    {
        GameObject newTab = Instantiate(tabPrefab, tabsContainer);
        newTab.GetComponentInChildren<TextMeshProUGUI>().text = tabName;


        tabCount++;
    }

    public void CloseTab(GameObject tab)
    {
        Destroy(tab);
        tabCount--;
    }
}
