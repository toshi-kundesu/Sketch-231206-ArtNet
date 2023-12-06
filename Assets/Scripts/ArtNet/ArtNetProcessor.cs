using System.Collections.Generic;
using UnityEngine;
using ArtNet;
using System;
using static ArtNet.Utility;

public class ArtNetProcessor : MonoBehaviour
{
    // デバックを表示するかどうか
    [SerializeField]
    private bool _debug = false;
    // UDPReceiverの参照
    public UDPReceiver udpReceiver;

    // データ受信イベントの定義
    public event Action<byte[]> ArtNetReceivedEvent;

    #region fpsCounter
    [SerializeField]
    private int _updateCounter = 0;
    [SerializeField]
    private int _dequeueCounter = 0;
    [SerializeField]
    private float _totalTime = 0;
    [SerializeField]
    private float _interbalTime = 5;
    #endregion

    // フレームが落ちても、ArtNetの処理損ないを防ぐ
    // メインスレッドに移行して、データを処理する
    // UDPパケットをArtNet型に変換してイベントを発行
    private void Update()
    {
        UpdateFPSCounter();
        
        // データキューがたまっていても、一定数以上のデータを処理しない
        int processLimit = 10;
        while (udpReceiver.dataQueue.Count > 0 && processLimit > 0)
        {
            byte[] udpData;
            lock (udpReceiver.queueLock)
            {
                if (udpReceiver.dataQueue.Count == 0)
                {
                    break;
                }
                udpData = udpReceiver.dataQueue.Dequeue(); // データを取り出す
            }

            // デキューしたUDPパケットがArtNetのデータかどうかを判定
            // ArtNetならイベントを発行
            if (IsArtNet(udpData))
            {
                Debug.Log("CH1: " + GetDmxData(udpData)[0]);
                Debug.Log("Univ. : " + GetUniverse(udpData));
                // Debug.Log("Sequence: " + GetSequence(udpData));
                // Debug.Log("Physical: " + GetPhysical(udpData));
                Debug.Log("Opcode: " + GetOpCode(udpData));
                // ArtNetReceivedEvent?.Invoke(new ArtNetData(udpData));;
                ArtNetReceivedEvent?.Invoke(udpData);
            }
            
            processLimit--;
            _dequeueCounter++;
        }
    }

    private void UpdateFPSCounter()
    {
        _updateCounter++;
        _totalTime += Time.deltaTime;
        if (_totalTime >= _interbalTime)
        {
            if (_debug)
            {
                Debug.Log("Update fps: " + _updateCounter / _interbalTime  + " Dequeue fps: " + _dequeueCounter / _interbalTime);
            }
            _updateCounter = 0;
            _dequeueCounter = 0;
            _totalTime = 0;
        }
    }
}