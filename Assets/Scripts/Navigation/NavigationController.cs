using UnityEngine;

public class NavigationController : MonoBehaviour
{
    [SerializeField] private NavigationView navView;
    [SerializeField] private RoomSO startingRoom;
    [SerializeField] private RoomDatabaseSO roomDatabase;
    
    private RoomSO currentRoom;
    
    public void Awake()
    {
        currentRoom = startingRoom;
        ShowCurrentRoom();
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
        ShowCurrentRoom();
    }

    private void ShowCurrentRoom()
    {
        navView.RefreshNavVisuals(
            currentRoom.adjRoomsUp, 
            currentRoom.adjRoomsDown, 
            currentRoom.adjRoomsLeft, 
            currentRoom.adjRoomsRight
            );
    }
    
    private RoomSO GetRoomByID(int roomID)
    {
        return roomDatabase.GetRoomByID(roomID);
    }
}
