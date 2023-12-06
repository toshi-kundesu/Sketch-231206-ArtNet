using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class IPAddressLister : MonoBehaviour
{
    [SerializeField]
    private List<string> ipList = new List<string>();
    [ContextMenu("GetAvailableIPs")]
    public List<string> GetAvailableIPs()
    {
        // 既存のリストをクリア
        ipList.Clear();

        // すべてのネットワークインターフェースを取得
        NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

        foreach (NetworkInterface networkInterface in interfaces)
{
    // ネットワークインターフェースがアクティブであることを確認
    if (networkInterface.OperationalStatus == OperationalStatus.Up)
    {
        // 各ネットワークインターフェースに対して、IPアドレスを取得
        IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();
        UnicastIPAddressInformationCollection unicastAddresses = ipProperties.UnicastAddresses;

        foreach (UnicastIPAddressInformation unicastAddress in unicastAddresses)
        {
            // IPv4アドレスのみをリストに追加
            if (unicastAddress.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                ipList.Add(unicastAddress.Address.ToString());
            }
        }
    }
}

        return ipList;
    }
}