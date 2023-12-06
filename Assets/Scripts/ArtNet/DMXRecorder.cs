using System.IO;
using UnityEngine;
using ArtNet;
using System;
using UnityEditor;
using static ArtNet.Utility;
public class DMXRecorder : MonoBehaviour
{
    public KeyCode triggerStartKey = KeyCode.A; // 録音開始キー
    public KeyCode triggerStopKey = KeyCode.B;  // 録音停止キー
    private const string DefaultFolderPath = "DMXSequences";
    private const string DefaultSequenceName = "DMXSequence";

    [SerializeField] private ArtNetProcessor artNetPort;
    [SerializeField] private string folderPath = DefaultFolderPath;
    [SerializeField] private string sequenceName = DefaultSequenceName;

    private AnimationCurve[] dmxChannelCurves;
    [SerializeField]
    private float elapsedTime;
    [SerializeField]
    private bool isRecordingActive;

    private void Update()
    {
        if (isRecordingActive) 
        {
            elapsedTime += Time.deltaTime;
        }

        if (Input.GetKeyDown(triggerStartKey)) 
        {
            BeginRecording();
        }
        if (Input.GetKeyDown(triggerStopKey)) 
        {
            EndRecording();
        }
    }

    private void BeginRecording()
    {
        if (isRecordingActive) return;
        isRecordingActive = true;
        try
        {
            PrepareForRecording();
            artNetPort.ArtNetReceivedEvent += CaptureDMXSignal;
            Debug.Log("Recording has begun");
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to start recording: {e}");
            isRecordingActive = false;
        }
    }

    private void PrepareForRecording()
    {
        dmxChannelCurves = ArtNet.Utility.GenerateDMXChannelCurves();
        elapsedTime = 0f;
        isRecordingActive = true;
    }

    private void CaptureDMXSignal(byte[] artNetData)
    {
        if (GetOpCode(artNetData) != ArtNet.OpCode.OpDmx) return;
        for (int i = 0; i < (int)ArtNet.Number.DmxChannelCount; i++)
        {
            ArtNet.Utility.SimplifyDMXChannelCurve(dmxChannelCurves[i], GetDmxData(artNetData)[i]);

            var key = new Keyframe(elapsedTime, GetDmxData(artNetData)[i]);
            dmxChannelCurves[i].AddKey(key);
        }

    }

    public void OnDisable()
    {
        this.EndRecording();
    }

    private void EndRecording()
    {
        if (!isRecordingActive) return;
        isRecordingActive = false;
        try
        {
            AnimationClip clip = ArtNet.Utility.GenerateAnimationClip(dmxChannelCurves);
            for (int i = 0; i < (int)ArtNet.Number.DmxChannelCount; i++) clip.SetCurve("", typeof(DMXChannel), $"Ch{i + 1}", dmxChannelCurves[i]);
            artNetPort.ArtNetReceivedEvent -= CaptureDMXSignal;
            dmxChannelCurves = null;

            ArtNet.Utility.StoreAnimationClip(clip, folderPath, sequenceName);
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to stop recording: {e}");
        }
    }
}
