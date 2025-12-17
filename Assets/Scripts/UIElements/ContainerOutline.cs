using UnityEngine;

[ExecuteAlways]
public class ContainerOutline : MonoBehaviour
{
    public RectTransform containerRect;

    private LineRenderer outline;

    private void Awake()
    {
        outline = GetComponent<LineRenderer>();
        outline.positionCount = 4;

        UpdateOutline();
    }

    private void OnEnable()
    {
        UpdateOutline();
    }
    
    //Testing things because why unity not draw line
#if UNITY_EDITOR
    private void OnValidate()
    {
        if (!Application.isPlaying)
        {
            if (outline == null)
                outline = GetComponent<LineRenderer>();
            if (containerRect == null)
                containerRect = GetComponent<RectTransform>();

            if (outline != null)
            {
                outline.loop = true;
                outline.positionCount = 4;
            }
            UpdateOutline();
        }
    }
#endif


    public void UpdateOutline()
    {
        Vector3[] corners = new Vector3[4];
        containerRect.GetWorldCorners(corners);
        outline.SetPositions(corners);
    }

    public void SetColor(Color color)
    {
        outline.startColor = color;
        outline.endColor = color;
    }
}
