using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "RoomDatabaseSO", menuName = "Scriptable Objects/RoomDatabaseSO")]
public class RoomDatabaseSO : ScriptableObject
{
    [SerializeField] private List<RoomSO> rooms = new List<RoomSO>();
    
    private Dictionary<int, RoomSO> roomLookup = new Dictionary<int, RoomSO>();

    private void OnEnable()
    {
        InitializeLookup();
    }

    private void InitializeLookup()
    {
        foreach (RoomSO room in rooms)
        {
            if (room == null) continue;
            
            roomLookup[room.roomID] = room;
        }
    }

    public RoomSO GetRoomByID(int roomID)
    {
        return roomLookup.TryGetValue(roomID, out RoomSO room) ? room : null;
    }
    
}
