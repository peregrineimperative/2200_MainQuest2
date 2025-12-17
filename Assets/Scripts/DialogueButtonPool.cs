using UnityEngine;
using System.Collections.Generic;

public class DialogueButtonPool : MonoBehaviour
{
    [SerializeField] private GameObject dialogueButtonPrefab;
    [SerializeField] private Transform parent;
    [SerializeField] private int buttonPoolSize = 10;
    
    private List<GameObject> buttons = new List<GameObject>();

    private void Awake()
    {
        //instantiate all buttons and add to object pool
        for (int i = 0; i < buttonPoolSize; i++)
        {
            GameObject button = Instantiate(dialogueButtonPrefab, parent.transform);
            button.SetActive(false);
            buttons.Add(button);
        }
    }
}
