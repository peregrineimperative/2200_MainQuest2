using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

/// <summary>
/// Responsible for the visual representation of the room navigation screen.
/// </summary>
public class NavigationView : MonoBehaviour
{
    [Header("Button Object Pool")]
    [SerializeField] private NavigationButtonPool navButtonPool;
    
    //[Header("Prefabs")]
    //[SerializeField] private GameObject navButtonPrefab;
    //[SerializeField] private GameObject interactButtonPrefab;
    
    [Header("Button Parent Transforms")]
    [SerializeField] private Transform navButtonParentUp;
    [SerializeField] private Transform navButtonParentDown;
    [SerializeField] private Transform navButtonParentLeft;
    [SerializeField] private Transform navButtonParentRight;
    //[SerializeField] private Transform interactButtonParent;

    //Lists of IDs for adjacent rooms. (Normally only one in a given direction, but allows for more.)
    public List<int> AdjRoomsUp { get; set; }
    public List<int> AdjRoomsDown { get; set; }
    public List<int> AdjRoomsLeft { get; set; }
    public List<int> AdjRoomsRight { get; set; }

    //Delegates to inform NavigationController of button clicks
    public event Action<RoomSO> OnNavButtonClicked;
    
   
    
    public void RefreshNavVisuals(
        
    {
        navButtonPool.ReleaseAllButtons();
        
        foreach (int roomID in AdjRoomsUp)
        {
            GameObject newButton = Instantiate(navButtonPrefab, navButtonParentUp.transform);

            newButton.GetComponent<Button>().onClick.AddListener(() => OnNavButtonClicked?.Invoke(roomID));
        }
    }
    
    public void SetUpButtons
    
}
