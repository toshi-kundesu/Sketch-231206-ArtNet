using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public Transform target; // 追跡するオブジェクト
    public float damping = 5.0f; // ダンピングの値
    public float minFov = 15.0f; // 最小視野角
    public float maxFov = 90.0f; // 最大視野角
    public float zoomSpeed = 0.1f; // ズームの速度
    private Camera cam; // カメラコンポーネント
    private float time; // パーリンノイズの時間パラメータ

    void Start()
    {
        cam = GetComponent<Camera>();
        time = Random.Range(0f, 100f); // ランダムな初期時間
    }

    void LateUpdate()
    {
        if (target)
        {
            // ターゲットを見つめる
            Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * damping);

            // パーリンノイズに基づいてズーム
            time += Time.deltaTime * zoomSpeed;
            float noise = Mathf.PerlinNoise(time, 0f);
            cam.fieldOfView = Mathf.Lerp(minFov, maxFov, noise);
        }
    }
}