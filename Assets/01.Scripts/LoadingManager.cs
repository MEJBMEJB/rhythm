using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

/*
 * loading으로 thumnail(스플레쉬)을 띄운다
 * 어느정도 시간(_limitSplashTime에서 지정한 값) 지나면 스플레쉬를 비활성화 시킨다
 * 선택한 음악을 재생한다
 * 음악이 끝나면 결과 Scene로 화면을 옮긴다
 * 
 */

static class ConstantsLoading
{
    public const float _limitSplashTime = 1.5f;
}



public class LoadingManager : MonoBehaviour
{
    private float _currentSplshTime; //스플래쉬 음악이 뜨는 시간
    private bool _isSplashPrint;
    private string _splashPath;

    [SerializeField]
    private Image _splashImage;
    [SerializeField]
    private AssetReferenceSprite[] _splashSprite;

    private void Awake()
    {
        _currentSplshTime = 0.0f;
        _isSplashPrint = true;
        _splashImage.GetComponent<Image>().enabled = true;
    }

    private void Start()
    {      
        //섬네일 경로가져오기
        _splashPath = Application.dataPath + "/03.Resource/03-02.Resource_Image/";
        _splashPath += ("song" + MoveSceneManger.Instance.currentSelectIndex.ToString() + ".png");

        _splashSprite[MoveSceneManger.Instance.currentSelectIndex].LoadAssetAsync().Completed += spriteLoad_Completed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isSplashPrint)
        {            
            return;
        }
        else
        {
            _currentSplshTime += Time.deltaTime;
            if (_currentSplshTime > ConstantsLoading._limitSplashTime)
            {
                _isSplashPrint = false;
                _splashImage.GetComponent<Image>().enabled = false;
                SoundManager.soundInstance.PlaySound(MoveSceneManger.Instance.currentSelectIndex);
            }
        }
    }

    private void spriteLoad_Completed(AsyncOperationHandle<Sprite> operation)
    {
        if (operation.Status == AsyncOperationStatus.Succeeded)
        {
            _splashImage.sprite = operation.Result;
            RectTransform rect = (RectTransform)_splashImage.transform;
            rect.sizeDelta = new Vector2(800,600);
        }
        else
        {
            Debug.LogError($"Asset For {_splashPath} failed to load.");
        }
    }
}
