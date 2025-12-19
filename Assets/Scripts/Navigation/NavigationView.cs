using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using TMPro;

/// <summary>
/// Responsible for the visual representation of the room navigation screen.
/// </summary>
public class NavigationView : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject navButtonPrefab;
    [SerializeField] private GameObject interactButtonPrefab;
    
    [Header("Button Parent Transforms")]
    [SerializeField] private Transform navButtonParentUp;
    [SerializeField] private Transform navButtonParentDown;
    [SerializeField] private Transform navButtonParentLeft;
    [SerializeField] private Transform navButtonParentRight;
    [SerializeField] private Transform interactButtonParent;
    
    [Header("Other UI References")]
    [SerializeField] private TMP_Text roomNameText;
    [SerializeField] private TMP_Text roomDescriptionText;

    //Button pools
    private ButtonPool<NavButtonView> navButtonPool;
    private ButtonPool<ButtonView> interactButtonPool;
    
    private void Awake()
    {
        navButtonPool = new ButtonPool<NavButtonView>(navButtonPrefab, transform, 12);
        interactButtonPool = new ButtonPool<ButtonView>(interactButtonPrefab, interactButtonParent, 10);
    }
    
    //Delegates to inform NavigationController of button clicks
    public event Action<RoomSO> OnNavButtonClicked;
    public event Action<CharacterSO> OnInteractButtonClicked;
    
    public void RefreshNavVisuals(
        List<RoomSO> adjRoomsUp, 
        List<RoomSO> adjRoomsDown, 
        List<RoomSO> adjRoomsLeft, 
        List<RoomSO> adjRoomsRight,
        List<CharacterSO> characters,
        string currentRoomName,
        string currentRoomDescription)
    {
        navButtonPool.ReleaseAllButtons();
        SetDirectionalButtons(adjRoomsUp, navButtonParentUp);
        SetDirectionalButtons(adjRoomsDown, navButtonParentDown);
        SetDirectionalButtons(adjRoomsLeft, navButtonParentLeft);
        SetDirectionalButtons(adjRoomsRight, navButtonParentRight);
        
        SetInteractionButtons(characters, interactButtonParent);
        
        roomNameText.text = currentRoomName;
        roomDescriptionText.text = currentRoomDescription;
    }

    private void SetDirectionalButtons(List<RoomSO> rooms, Transform parent)
    {
        foreach (RoomSO room in rooms) {
            NavButtonView buttonView = navButtonPool.GetButton(parent);
            
            //Testing
            if (buttonView == null)
            {
                Debug.LogWarning("Failed to get button from pool!");
                continue;
            }
            var buttonText = buttonView.buttonText;
            
            //Testing
            if (buttonText == null)
            {
                Debug.LogWarning("Failed to get button text from button!");
                continue;
            }
            
            buttonView.buttonText.text = room.roomName;
            
            buttonView.button.onClick.AddListener(() => OnNavButtonClicked?.Invoke(room));
            
            buttonView.gameObject.SetActive(true);
        }
    }

    private void SetInteractionButtons(List<CharacterSO> characters, Transform parent)
    {
        foreach (CharacterSO character in characters)
        {
            ButtonView buttonView = interactButtonPool.GetButton(parent);
            
            buttonView.ButtonText.text = character.characterName;
            
            buttonView.Button.onClick.AddListener(() => OnInteractButtonClicked?.Invoke(character));
            
            buttonView.gameObject.SetActive(true);
        }
    }
    
}
