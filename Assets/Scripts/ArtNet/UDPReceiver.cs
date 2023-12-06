using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using System.Collections.Generic;

public class UDPReceiver : MonoBehaviour
{
    // スレッドとUDPクライアントの宣言
    private Thread _udpThread;
    private UdpClient _udpClient;

    // スレッドの動作状態を追跡するためのフラグ
    private bool _isThreadRunning = false;
    public Queue<byte[]> dataQueue = new Queue<byte[]>();
    public object queueLock = new object();
    // リッスンするIPアドレスとポート番号
    [SerializeField]
    private string _listenAddress = "127.0.0.1"; // IPアドレス
    private int _listenPort = (int)ArtNet.Number.Port; // Art-Netポート番号

    void Start()
    {
        // スレッドを開始する前にリッスン状態を設定
        _isThreadRunning = true;
        
        // 特定のIPアドレスとポートでUDPクライアントを初期化
        IPAddress ipAddress = IPAddress.Parse(_listenAddress);
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, _listenPort);
        _udpClient = new UdpClient(localEndPoint);

        // UDPリッスン用のスレッドを開始
        _udpThread = new Thread(new ThreadStart(ThreadMethod));
        _udpThread.IsBackground = true;
        _udpThread.Start();
    }

    private void ThreadMethod()
    {
        // スレッドが動作中である間続けてUDPパケットを受信
        while (_isThreadRunning)
        {
            try
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, _listenPort);
                byte[] receivedBytes = _udpClient.Receive(ref remoteEndPoint);

                lock (queueLock)
                {
                    dataQueue.Enqueue(receivedBytes);
                }
            }
            catch (Exception e)
            {
                // スレッドが停止している場合は例外を無視
                if (!_isThreadRunning)
                {
                    break;
                }
                Debug.LogError(e.ToString());
            }
        }
    }

    private void OnDisable()
    {
        // アプリケーション終了時にスレッドとUDPクライアントを終了
        _isThreadRunning = false;
        if (_udpClient != null) 
        {
            _udpClient.Close();
        }
        if (_udpThread != null)
        {
            _udpThread.Join();
        }
    }
}