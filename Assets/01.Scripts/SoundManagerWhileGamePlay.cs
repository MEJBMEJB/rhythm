using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

/*
 * 게임플레이 진행중 실행되는 배경음

 
 */
public class SoundManagerWhileGamePlay : MonoBehaviour
{
    private AudioSource _currntPlayAudio;
    //private AudioClip _currnetPlayBGM; //현재 실행중인 음악
    [SerializeField]
    private AssetLabelReference _assetLabel; //라벨을 설정한다

    // Start is called before the first frame update
    void Start()
    {
        _currntPlayAudio = GetComponent<AudioSource>();

        //라벨 문자열을 가져온다
        //Addressables.InstantiateAsync(_assetLabel.labelString);
        //Debug.Log($"_assetLabelString = {_assetLabel.labelString}");

        Addressables.LoadResourceLocationsAsync(_assetLabel.labelString).Completed += handle =>
        {
            var ListBGM = handle.Result;

            Addressables.InstantiateAsync(ListBGM[MoveSceneManger.Instance.currentSelectIndex]).Completed += playBGM;
        };

    }

    private void playBGM(AsyncOperationHandle<GameObject> obj)
    {
        GameObject tmp = obj.Result;
        //tmp.GetComponent<AudioSource>().Play();
        //_currntPlayAudio.PlayOneShot(tmp.GetComponent<AudioSource>.);
    }

    // Update is called once per frame
    void Update()
    {
       // _currntPlayAudio.PlayOneShot(_currnetPlayBGM);
    }
}
