using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelectMusicButton : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _musicName;
    [SerializeField]
    private TMP_Text _artistName;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Sprite[] _spThumnail;

    //public int buttonValue
    //{
    //    get => _buttonValue;
    //    set => _buttonValue = value;
    //}

    public string musicName
    {
        get => _musicName.text;
        set => _musicName.text = value;
    }

    public string artistName
    {
        get => _artistName.text;
        set => _artistName.text = value;
    }

    private void Awake()
    {
    //    buttonValue = -1;
    }

    private void Start()
    {
        Debug.Log($"make prefab = {this.gameObject.name}");
                
        if (this.gameObject.name == "0") 
        {
            _image.GetComponent<Image>().sprite = _spThumnail[0];
        }
        else if(this.gameObject.name == "1")
        {
            _image.GetComponent<Image>().sprite = _spThumnail[1];
        }


    }
}