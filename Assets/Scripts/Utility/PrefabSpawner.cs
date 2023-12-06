using UnityEngine;
using System.Collections.Generic;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab; // 複製するPrefab
    [SerializeField] private int channelCount = 9; // 複製するPrefabのDMXアドレス数
    [SerializeField] private int count = 10; // 複製する数
    [SerializeField] private Vector3 interval = new Vector3(2f, 0f, 0f); // 配置する間隔
    [SerializeField] private Vector3 rowInterval = new Vector3(0f, 0f, 2f); // 行間隔
    [SerializeField] private int perRow = 5; // 一行あたりのPrefab数

    [SerializeField] private Quaternion rotation = Quaternion.identity; // 生成するオブジェクトの向き
    [SerializeField]
    private List<GameObject> spawnedObjects = new List<GameObject>(); // 生成したオブジェクトのリスト

    [ContextMenu("Spawn")]
    void Start()
    {
        // 既に生成したオブジェクトがあれば全て破棄
        foreach (var obj in spawnedObjects)
        {
            if (Application.isPlaying)
            {
                Destroy(obj);
            }
            else
            {
                DestroyImmediate(obj);
            }
        }
        spawnedObjects.Clear();

        for (int i = 0; i < count; i++)
        {
            // 行と列を計算
            int row = i / perRow;
            int col = i % perRow;

            // Prefabを複製
            GameObject obj = Instantiate(prefab, transform.position + interval * col + rowInterval * row, rotation, transform);
            spawnedObjects.Add(obj);

            // RGBWLightControllerを取得し、startAddressを設定
            RGBWLightController controller = obj.GetComponent<RGBWLightController>();
            if (controller != null)
            {
                controller.startAddress = 1 + (i % perRow) * channelCount;
            }
        }
    }
}