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

    public void OnNavButtonClicked(RoomSO targetRoom)
    {
        currentRoom = targetRoom;
    }
}
