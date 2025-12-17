using UnityEngine;
using System.Collections.Generic;

public class NavigationButtonPool : MonoBehaviour
{
    [SerializeField] private GameObject navigationButtonPrefab;
    [SerializeField] private Transform parent;
    [SerializeField] private int buttonPoolSize = 10;
    
    private List<GameObject> buttons = new List<GameObject>();

    private void Awake()
    {
        //instantiate all buttons and add to object pool
        for (int i = 0; i < buttonPoolSize; i++)
        {
            GameObject button = Instantiate(navigationButtonPrefab, parent.transform);
            button.SetActive(false);
            buttons.Add(button);
        }
    }
}
