using UnityEngine;

public class PerlinNoizeMotion : MonoBehaviour
{
    public Vector3 positionAmplitude = Vector3.one;
    public Vector3 rotationAmplitude = Vector3.one * 10.0f;
    public float frequency = 1.0f;
    public bool useRandomMotion = true;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private float time;
    private float randomOffsetX;
    private float randomOffsetY;

    void Start()
    {
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;

        if (useRandomMotion)
        {
            // ランダムシードを生成
            int randomSeed = Random.Range(0, int.MaxValue);
            Random.InitState(randomSeed);
            randomOffsetX = Random.value * 1000.0f;
            randomOffsetY = Random.value * 1000.0f;
        }
    }

    void Update()
    {
        time += Time.deltaTime * frequency;

        float offsetX = useRandomMotion ? randomOffsetX : 0.0f;
        float offsetY = useRandomMotion ? randomOffsetY : 0.0f;

        float x = initialPosition.x + (Remap(Mathf.PerlinNoise(time + offsetX, 0), 0, 1, -positionAmplitude.x, positionAmplitude.x));
        float y = initialPosition.y + (Remap(Mathf.PerlinNoise(0, time + offsetY), 0, 1, -positionAmplitude.y, positionAmplitude.y));
        float z = initialPosition.z + (Remap(Mathf.PerlinNoise(time + offsetX, time + offsetY), 0, 1, -positionAmplitude.z, positionAmplitude.z));

        transform.localPosition = new Vector3(x, y, z);

        float rx = Remap(Mathf.PerlinNoise(time + offsetX, 0), 0, 1, -rotationAmplitude.x, rotationAmplitude.x);
        float ry = Remap(Mathf.PerlinNoise(0, time + offsetY), 0, 1, -rotationAmplitude.y, rotationAmplitude.y);
        float rz = Remap(Mathf.PerlinNoise(time + offsetX, time + offsetY), 0, 1, -rotationAmplitude.z, rotationAmplitude.z);

        transform.localRotation = Quaternion.Euler(rx, ry, rz) * initialRotation;
    }

    // 値を新しい範囲にリマップする関数
    float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}