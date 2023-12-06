using UnityEngine;
// using ArtNet.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtNet;
using static ArtNet.Utility;


public class ArtNetToDMXChannel : MonoBehaviour
{
    [Header("[ArtNet Settings]")]
    [SerializeField] private ArtNetProcessor artNetProcessor;

    [Header("[ArtNet Channels]")]
    [SerializeField] private DMXChannel artNetChannels;

    private async void Start()
    {
        artNetProcessor.ArtNetReceivedEvent += artNetData => UpdateDMXChannel(artNetData);
    }

    private void UpdateDMXChannel(byte[] artNetData)
    {
        if (GetOpCode(artNetData) == ArtNet.OpCode.OpDmx)
        {

                for (int i = 1; i <= (int)ArtNet.Number.DmxChannelCount; i++)
                {
                    artNetChannels[i] = GetDmxData(artNetData)[i - 1];
                }

        }
        else
        {
            Debug.Log("Not OpDmx: " + GetOpCode(artNetData) + "Description: " + OpCodeDescriptions[GetOpCode(artNetData)]);
        }
    }
}