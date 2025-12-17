using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class NavigationButtonPool : MonoBehaviour
{
    [SerializeField] private GameObject navigationButtonPrefab;
    [SerializeField] private Transform defaultParent;
    [SerializeField] private int buttonPoolSize = 10;
    
    //private List<GameObject> buttons = new List<GameObject>();
    private readonly Queue <GameObject> buttons = new Queue<GameObject>();
    private readonly HashSet<GameObject> activeButtons = new HashSet<GameObject>();
    
    private void Awake()
    {
        //instantiate all buttons and add to object pool
        for (int i = 0; i < buttonPoolSize; i++)
        {
            GameObject button = Instantiate(navigationButtonPrefab, defaultParent);
            button.SetActive(false);
            buttons.Enqueue(button);
        }
    }

    public GameObject GetButton(Transform parent)
    {
        GameObject button = buttons.Dequeue();
        button.transform.SetParent(parent);
        activeButtons.Add(button);
        return button;
    }

    public void ReleaseButton(GameObject button)
    {
        //return to pool
        activeButtons.Remove(button);
        buttons.Enqueue(button);

        //clear previous navigation assignment
        var listener = button.GetComponent<Button>();
        if (listener != null) listener.onClick.RemoveAllListeners();

        //deactivate and remove from parent
        button.SetActive(false);
        button.transform.SetParent(defaultParent, false);
    }

    public void ReleaseAllButtons()
    {
        var toRelease = new List<GameObject>(activeButtons);
        foreach (GameObject button in toRelease) ReleaseButton(button);
    }
    
}
