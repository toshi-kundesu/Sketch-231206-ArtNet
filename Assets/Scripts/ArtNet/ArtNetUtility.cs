using System;
using UnityEngine;
using ArtNet;
using System.IO;
using UnityEditor;
using System.Collections.Generic;

namespace ArtNet{

    public static class Utility
    {
        #region OpCodeDescriptions
        public static readonly Dictionary<OpCode, string> OpCodeDescriptions = new Dictionary<OpCode, string>
        {
            { OpCode.OpPoll, "Art-Netデバイスの状態を問い合わせる" },
            { OpCode.OpPollReply, "OpPollに対する応答" },
            { OpCode.OpDiagData, "診断データ" },
            { OpCode.OpCommand, "テキストベースのコマンド" },
            { OpCode.OpDmx, "DMXデータ" },
            { OpCode.OpNzs, "非ゼロスタートコードを持つDMXデータ" },
            { OpCode.OpSync, "DMXデータの同期信号" },
            { OpCode.OpAddress, "Art-Netデバイスの設定" },
            { OpCode.OpInput, "入力ポートの設定" },
            { OpCode.OpTodRequest, "RDMデバイスのデータ要求" },
            { OpCode.OpTodData, "RDMデバイスのデータ" },
            { OpCode.OpTodControl, "RDMデバイスの制御" },
            { OpCode.OpRdm, "RDMデータ" },
            { OpCode.OpRdmSub, "RDMサブデータ" },
            { OpCode.OpVideoSetup, "ビデオ設定" },
            { OpCode.OpVideoPalette, "ビデオパレットデータ" },
            { OpCode.OpVideoData, "ビデオデータ" },
            { OpCode.OpMacMaster, "MACマスターデータ" },
            { OpCode.OpMacSlave, "MACスレーブデータ" },
            { OpCode.OpFirmwareMaster, "ファームウェアアップデートマスターデータ" },
            { OpCode.OpFirmwareReply, "ファームウェアアップデート応答" },
            { OpCode.OpFileTnMaster, "ファイル転送マスターデータ" },
            { OpCode.OpFileFnMaster, "ファイル転送応答" },
            { OpCode.OpFileFnReply, "ファイル転送応答" },
            { OpCode.OpIpProg, "IP設定" },
            { OpCode.OpIpProgReply, "IP設定応答" },
            { OpCode.OpMedia, "メディアデータ" },
            { OpCode.OpMediaPatch, "メディアパッチデータ" },
            { OpCode.OpMediaControl, "メディア制御" },
            { OpCode.OpMediaContrlReply, "メディア制御応答" },
            { OpCode.OpTimeCode, "タイムコードデータ" },
            { OpCode.OpTimeSync, "タイム同期" },
            { OpCode.OpTrigger, "トリガーデータ" },
            { OpCode.OpDirectory, "ディレクトリ要求" },
            { OpCode.OpDirectoryReply, "ディレクトリ応答" },
        };
        #endregion
  
        #region UdpUtility
        public static bool IsArtNet(byte[] buffer)
        {
            if (buffer.Length < 8) return false;

            if (buffer[0] == 'A' &&
                buffer[1] == 'r' &&
                buffer[2] == 't' &&
                buffer[3] == '-' &&
                buffer[4] == 'N' &&
                buffer[5] == 'e' &&
                buffer[6] == 't' &&
                buffer[7] == 0x00) return true;
            else return false;
        }

        // OpCodeを取得
        public static ArtNet.OpCode GetOpCode(byte[] buffer)
        {
            return (ArtNet.OpCode)BitConverter.ToInt16(new byte[] { buffer[8], buffer[9] }, 0);
        }

        // Universeを取得
        public static int GetUniverse(byte[] buffer)
        {
            // if (buffer.Length < 18) return -1;
            return BitConverter.ToInt16(new byte[] { buffer[14], buffer[15] }, 0);
        }

        // データ長を取得
        public static int GetLength(byte[] buffer)
        {
            if (buffer.Length < 18) return -1;
            return BitConverter.ToInt16(new byte[] { buffer[17], buffer[16] }, 0);
        }

        // DMXデータを取得
        public static byte[] GetDmxData(byte[] buffer)
        {
            int dataLength = GetLength(buffer);
            if (dataLength <= 0 || buffer.Length < dataLength + 18) return null;

            byte[] dmxData = new byte[dataLength];
            Array.Copy(buffer, 18, dmxData, 0, dataLength);
            return dmxData;
        }
        #endregion
        #region ArtNetAnimationUtilities
        public static AnimationCurve[] GenerateDMXChannelCurves()
        {
            var dmxChannelCurves = new AnimationCurve[(int)Number.DmxChannelCount];
            for (int i = 0; i < dmxChannelCurves.Length; i++)
            {
                dmxChannelCurves[i] = new AnimationCurve();
            }
            return dmxChannelCurves;
        }

        public static void SimplifyDMXChannelCurve(AnimationCurve curve, float channelValue)
        {
            if (curve.keys.Length > 2)
            {
                var penultimateKeyIndex = curve.keys.Length - 2;
                var lastKeyIndex = curve.keys.Length - 1;
                var penultimateKey = curve.keys[penultimateKeyIndex];
                var lastKey = curve.keys[lastKeyIndex];

                if (penultimateKey.value == lastKey.value && lastKey.value == channelValue)
                {
                    curve.RemoveKey(penultimateKeyIndex);
                }
            }
        }

        public static AnimationClip GenerateAnimationClip(AnimationCurve[] dmxChannelCurves)
        {
            var clip = new AnimationClip();
            for (int i = 0; i < dmxChannelCurves.Length; i++)
            {
                clip.SetCurve("", typeof(DMXChannel), $"Channel_{i + 1}", dmxChannelCurves[i]);
            }
            return clip;
        }

        public static void StoreAnimationClip(AnimationClip clip, string folderPath, string sequenceName)
        {
            #if UNITY_EDITOR
            var relativeFolderPath = $"Assets/{folderPath}";
            var absoluteFolderPath = $"{Application.dataPath}/{folderPath}";
            if (!Directory.Exists(absoluteFolderPath)) 
                Directory.CreateDirectory(absoluteFolderPath);
            var baseFileName = $"{relativeFolderPath}/{sequenceName}";
            var fileSuffix = 0;
            string relativeFilePath, absoluteFilePath;
            do
            {
                relativeFilePath = fileSuffix > 0 ? $"{baseFileName}({fileSuffix}).asset" : $"{baseFileName}.asset";
                absoluteFilePath = $"{absoluteFolderPath}/{sequenceName}{(fileSuffix > 0 ? $"({fileSuffix})" : "")}.asset";
                fileSuffix++;
            } while (File.Exists(absoluteFilePath));
            AssetDatabase.CreateAsset(clip, relativeFilePath);
            AssetDatabase.Refresh();
            #endif
        }
        #endregion
    }

    // ポート番号管理クラス
    public enum Number
    {
        // ポート番号
        Port = 6454,
        // DMXのチャンネル数
        DmxChannelCount = 512,
        // Art-Netパケットのサイズ
        ArtNetPacketSize = 530,
    }
    #region ArtNetOpCode
    public enum OpCode
    {
        OpPoll = 0x2000,
        OpPollReply = 0x2100,
        OpDiagData = 0x2300,
        OpCommand = 0x2400,
        OpDmx = 0x5000,
        OpNzs = 0x5100,
        OpSync = 0x5200,
        OpAddress = 0x6000,
        OpInput = 0x7000,
        OpTodRequest = 0x8000,
        OpTodData = 0x8100,
        OpTodControl = 0x8200,
        OpRdm = 0x8300,
        OpRdmSub = 0x8400,
        OpVideoSetup = 0xa010,
        OpVideoPalette = 0xa020,
        OpVideoData = 0xa040,
        OpMacMaster = 0xf000,
        OpMacSlave = 0xf100,
        OpFirmwareMaster = 0xf200,
        OpFirmwareReply = 0xf300,
        OpFileTnMaster = 0xf400,
        OpFileFnMaster = 0xf500,
        OpFileFnReply = 0xf600,
        OpIpProg = 0xf800,
        OpIpProgReply = 0xf900,
        OpMedia = 0x9000,
        OpMediaPatch = 0x9100,
        OpMediaControl = 0x9200,
        OpMediaContrlReply = 0x9300,
        OpTimeCode = 0x9700,
        OpTimeSync = 0x9800,
        OpTrigger = 0x9900,
        OpDirectory = 0x9a00,
        OpDirectoryReply = 0x9b00,
    }
    #endregion
}
