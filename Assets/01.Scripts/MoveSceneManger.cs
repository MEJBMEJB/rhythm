using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 * 씬이동 함수를 담은 클래스
 * 
 */
public class MoveSceneManger : MonoBehaviour
{
    private static MoveSceneManger _instance;
    private int _currentIndex;    

    public int currentSelectIndex
    {
        get => _currentIndex;
        set => _currentIndex = value;
    }

    public static MoveSceneManger Instance
    {
        get => _instance;
    }

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        _currentIndex = 0;

    }

    public void MoveScene_Option00()
    {
        Debug.Log("Go - Option Scene");
        SceneManager.LoadScene("OptionScene00");
    }

    public void MoveScene_Result()
    {
        SceneManager.LoadScene("ResultScene");
    }

    //public void SelectMusic_Prev()
    //{
    //    GameObject objTmp;
    //    objTmp = GameObject.Find("Canvas");
    //    int value = objTmp.GetComponent<MusicListEvent>().ListCount();
    //    if (_currentIndex == 0)
    //    {
    //        _currentIndex = value - 1;
    //    }
    //    else
    //    {
    //        _currentIndex--;
    //    }
    //    Debug.Log($"Prev = {_currentIndex}");
    //}
    //
    //public void SelectMusic_Next()
    //{
    //    GameObject objTmp;
    //    objTmp = GameObject.Find("Canvas");
    //    int value = objTmp.GetComponent<MusicListEvent>().ListCount();
    //    if (_currentIndex == value - 1)
    //    {
    //        _currentIndex = 0;
    //    }
    //    else
    //    {
    //        _currentIndex++;
    //    }
    //    Debug.Log($"Next = {_currentIndex}");
    //}

    public void MoveScene_MainGame()
    {
        switch (_currentIndex) 
        {
            case -1:
            default:
                break;
            case 0:
                SceneManager.LoadScene("GameScene00");
                break;
            case 1:
                SceneManager.LoadScene("GameScene01");
                break;
        }
        Debug.Log($"_currentIndex = {_currentIndex}");
    }

    public void MusicSelectOnValueChange()
    {

    }

    public void MoveScene_MainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ExitGame()
    {

    }
}
