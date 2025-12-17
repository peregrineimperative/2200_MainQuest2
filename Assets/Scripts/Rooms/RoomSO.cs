using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "RoomSO", menuName = "Room SO")]
public class RoomSO : ScriptableObject
{
    [Header("Room Info")]
    public int roomID;
    public string roomName;
    public string roomDescription;
    public Sprite roomBackground;
    
    [Header("Room Adjacency")]
    public List<RoomSO> adjRoomsUp;
    public List<RoomSO> adjRoomsDown;
    public List<RoomSO> adjRoomsLeft;
    public List<RoomSO> adjRoomsRight;
    
    [Header("Room Contents")]
    public List<CharacterSO> characters;
    //other interactable objects
}
