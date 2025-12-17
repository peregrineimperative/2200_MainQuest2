using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NavButtonView : MonoBehaviour
{
    [SerializeField] public Button button;
    [SerializeField] public TMP_Text buttonText;

    private void Awake()
    {
        if(button ==null) button = GetComponent<Button>();
        if(buttonText == null) buttonText = GetComponentInChildren<TMP_Text>();
    }
    
}
