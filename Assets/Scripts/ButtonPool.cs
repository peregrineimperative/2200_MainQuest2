using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


/// <summary>
/// Object pool for any buttons.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ButtonPool<T> where T: Component
{
    private readonly GameObject buttonPrefab;
    private readonly Transform defaultParent;
    private int poolSize;
    
    //Queue for holding inactive buttons; hashset for holding active buttons
    private readonly Queue <T> buttons = new Queue<T>();
    private readonly HashSet<T> activeButtons = new HashSet<T>();
    
    public ButtonPool(GameObject prefab, Transform parent, int size)
    {
        buttonPrefab = prefab;
        defaultParent = parent;
        poolSize = size;
        
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject buttonObj = Object.Instantiate(buttonPrefab, defaultParent);
            T component = buttonObj.GetComponent<T>();
            
            if (component == null)
            {
                Debug.LogError($"Prefab does not have component of type {typeof(T)}");
                continue;
            }
            
            buttonObj.SetActive(false);
            buttons.Enqueue(component);
        }

    }
    
    public T GetButton(Transform parent = null)
    {
        if (buttons.Count == 0)
        {
            Debug.LogError("No buttons available in pool!");
            return null;
        }
        
        T button = buttons.Dequeue();
        button.transform.SetParent(parent ?? defaultParent);
        activeButtons.Add(button);
        return button;
    }

    public void ReleaseButton(T button)
    {
        if (button == null || !activeButtons.Contains(button)) return;
        
        //return to pool
        activeButtons.Remove(button);
        buttons.Enqueue(button);

        //clear previous navigation assignment
        if (button is Button listener) listener.onClick.RemoveAllListeners();

        //deactivate and remove from parent
        button.gameObject.SetActive(false);
        button.transform.SetParent(defaultParent, false);
    }

    public void ReleaseAllButtons()
    {
        var toRelease = new List<T>(activeButtons);
        foreach (T button in toRelease) ReleaseButton(button);
    }
}
