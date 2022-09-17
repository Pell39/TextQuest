using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Action
{
    public string Description;
    public int Index;

    public Action(string description, int index)
    {
        Description = description;
        Index = index;
    }
}

[Serializable]
public class Room
{
    public string Description;
    public Action[] Actions;

    public Room(string description, Action[] actions)
    {
        Description = description;
        Actions = actions;
    }
}

public class TextQuest : MonoBehaviour
{
    /*
    Bad code!
    
    public TMP_Text RoomDesc;
    public Button[] ActionButtons;
    */

    [SerializeField]
    private TMP_Text _roomDesc;

    [SerializeField]
    private Button[] _actionButtons;

    /*
     Структура описания комнаты

    комната = [
        'Описание комнаты',
        ['Действие1', индекс_комнаты],
        ['Действие2', индекс_комнаты],
    ]
     */

    [SerializeField]
    private Room[] _rooms;

    private void ShowRoom(int index)
    {
        _roomDesc.text = _rooms[index].Description;

        for (var i = 0; i < _actionButtons.Length; i++)
        {
            _actionButtons[i].gameObject.SetActive(false);
        }

        for (var i = 0; i < _rooms[index].Actions.Length; i++)
        {
            _actionButtons[i].GetComponentInChildren<TMP_Text>().text = _rooms[index].Actions[i].Description;
            _actionButtons[i].gameObject.SetActive(true);
        }
    }

    private void Start()
    {
        var index = 0;
        ShowRoom(index);
    }
}
