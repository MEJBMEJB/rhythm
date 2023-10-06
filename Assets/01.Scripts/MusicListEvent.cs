using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

struct musicInfo
{
    private string _musicName;
    private string _artistName;

    public void setInfo(string musicName, string artistName)
    {
        _musicName = musicName;
        _artistName = artistName;
    }
    public string getString(int sel)
    {
        string strTmp = "";
        switch (sel)
        {
            case 0:
                strTmp = _musicName;
                break;
            case 1:
                strTmp = _artistName;
                break;
        }
        return strTmp;
    }
}
public class MusicListEvent : MonoBehaviour
{
    private List<musicInfo> _musicList;
    public int ListCount()
    {
        return _musicList.Count;   
    }
    [SerializeField]
    private GameObject _ListButton;
    [SerializeField]
    private GameObject _soundHelper;
    [SerializeField]
    private RectTransform _RectView;
    [SerializeField]
    private Transform _otherPos;
    [SerializeField]
    private Transform _curPos;

    private void Awake()
    {
        _musicList = new List<musicInfo>();

        //음악리스트 초기화
        #region InitMusicList
        musicInfo tmp = new musicInfo();
        tmp.setInfo("POP STARS", "KDA");
        _musicList.Add(tmp);

        tmp.setInfo("DragonRider", "Two Steps From Hell");
        _musicList.Add(tmp);

        tmp.setInfo("슈퍼갤럭시 럼블 Login", "LOL");
        _musicList.Add(tmp);

        tmp.setInfo("HIT", "Seventeen");
        _musicList.Add(tmp);

        tmp.setInfo("BUNGEE", "오마이걸");
        _musicList.Add(tmp);

        #endregion

        //음악선택버튼 위치 초기화
        #region InitMusicButtonPosition
        GameObject objTmp;
        objTmp = Instantiate(_soundHelper, Vector3.zero, Quaternion.identity);

        for (int i = 0; i < _musicList.Count; i++)
        {
            objTmp = Instantiate(_ListButton, Vector3.zero, Quaternion.identity);
            objTmp.transform.SetParent(_RectView);
        //    if(i == 0)
        //        objTmp.transform.position = _curPos.position;
        //    else
        //        objTmp.gameObject.transform.position = _otherPos.position;

            objTmp.name = i.ToString();
            objTmp = GameObject.Find(objTmp.name);
            objTmp.GetComponent<SelectMusicButton>().musicName = _musicList[i].getString(0);
            objTmp.GetComponent<SelectMusicButton>().artistName = _musicList[i].getString(1);
        }
        SetListPosition(0);
        #endregion
    }

    public void SelectMusic_Prev()
    {
        int curIdx = MoveSceneManger.Instance.currentSelectIndex;
        if(curIdx == 0)
        {
            curIdx = _musicList.Count - 1;
            MoveSceneManger.Instance.currentSelectIndex = curIdx;
        }
        else
        {
            MoveSceneManger.Instance.currentSelectIndex--;
        }        
        SetListPosition(MoveSceneManger.Instance.currentSelectIndex);
        Debug.Log($"Prev = {MoveSceneManger.Instance.currentSelectIndex}");
    }

    public void SelectMusic_Next()
    {
        int curIdx = MoveSceneManger.Instance.currentSelectIndex;
        if(curIdx == _musicList.Count - 1)
        {
            MoveSceneManger.Instance.currentSelectIndex = 0;
        }
        else
        {
            MoveSceneManger.Instance.currentSelectIndex ++;
        }
        SetListPosition(MoveSceneManger.Instance.currentSelectIndex);
        Debug.Log($"Next = {MoveSceneManger.Instance.currentSelectIndex}");
    }

    private void SetListPosition(int curNum) //포지션을 맞춘다
    {
        GameObject objCur, objOther;

        objCur = GameObject.Find(curNum.ToString());

        for (int i = 0; i < _musicList.Count; i++)
        {
            if(curNum == i)
            {
                objCur.transform.position = _curPos.position;
            }
            else
            {
                objOther = GameObject.Find(i.ToString());
                objOther.transform.position = _otherPos.position;
            }
        }
        //소리재생
        SoundManager.soundInstance.PlaySound(curNum);
    }
}
