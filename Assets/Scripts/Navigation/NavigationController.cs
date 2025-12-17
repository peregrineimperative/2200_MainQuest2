using UnityEngine;

public class NavigationController : MonoBehaviour
{
    [SerializeField] private NavigationView navView;
    [SerializeField] private RoomSO startingRoom;
    
    private RoomSO currentRoom;
    
    public void Awake()
    {
        currentRoom = startingRoom;
    }

    private void OnEnable()
    {
        if (navView != null)
        {
            navView.OnNavButtonClicked += GoToRoom;
        }
    }

    private void OnDisable()
    {
        if (navView != null)
        {
            navView.OnNavButtonClicked -= GoToRoom;
        }
    }
    
    private void GoToRoom(RoomSO targetRoom)
    {
        currentRoom = targetRoom;
        
        
    }
}
