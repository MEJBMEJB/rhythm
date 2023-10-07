using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

/*
 * loading���� thumnail(���÷���)�� ����
 * ������� �ð�(_limitSplashTime���� ������ ��) ������ ���÷����� ��Ȱ��ȭ ��Ų��
 * ������ ������ ����Ѵ�
 * ������ ������ ��� Scene�� ȭ���� �ű��
 * 
 */

static class ConstantsLoading
{
    public const float _limitSplashTime = 1.5f;
}



public class LoadingManager : MonoBehaviour
{
    private float _currentSplshTime; //���÷��� ������ �ߴ� �ð�
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
        //������ ��ΰ�������
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
