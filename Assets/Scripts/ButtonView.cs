using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonView : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private LineRenderer lineRenderer;

    public Button Button => button;
    public TMP_Text ButtonText => buttonText;
    public LineRenderer LineRenderer => lineRenderer;
    
    private void Awake()
    {
        if(button ==null) button = GetComponent<Button>();
        if(buttonText == null) buttonText = GetComponentInChildren<TMP_Text>();
        if(lineRenderer == null) lineRenderer = GetComponentInChildren<LineRenderer>();
    }
}
