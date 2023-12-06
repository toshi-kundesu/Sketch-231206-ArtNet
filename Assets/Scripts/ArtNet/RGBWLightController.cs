using UnityEngine;

public enum MovingRotationAxis
{
    X,
    Y,
    Z
}

public class RGBWLightController : MonoBehaviour
{
    [SerializeField] private DMXChannel artNetChannels = null;
    public Light lightToControl; // 制御するライト
    [SerializeField] [Range(0.0f, 1.0f)]
    private float maxWhiteIntensity = 1.0f; // ホワイトの最大輝度
    [SerializeField] [Range(0.0f, 1.0f)]
    private float maxRGBIntensity = 10.0f; // RGBの最大輝度
    [SerializeField] private Renderer targetRenderer = null;
    [SerializeField] private float MaxRendererIntensity = 500.0f;
    [SerializeField] [Range(0.0f, 10000.0f)]
    private float maxLightIntensity = 100.0f; // ライトの最大輝度

    #region channels
    [SerializeField] public int startAddress = 1;
    [SerializeField] private int panChannel = 2; // DMXチャンネル
    [SerializeField] private int tiltChannel = 3; // DMXチャンネル
    [SerializeField] private int intensityChannel = 2; // DMXチャンネル

    [SerializeField] private int redChannel = 2;
    [SerializeField] private int greenChannel = 3;
    [SerializeField] private int blueChannel = 4;
    [SerializeField] private int whiteChannel = 5;

    [SerializeField] private float lightSmoothness = 0.1f; // ライトのスムーズさ
    private Quaternion panOrientationAverage = Quaternion.identity; // パンの方向の平均
    private Quaternion tiltOrientationAverage = Quaternion.identity; // チルトの方向の平均

    [SerializeField] private MovingRotationAxis panRotationAxis = MovingRotationAxis.Y;
    [SerializeField] private MovingRotationAxis tiltRotationAxis = MovingRotationAxis.Z;

    [SerializeField] private Transform _Panpart = null;
    [SerializeField] private Transform _Tiltpart = null;

    [SerializeField] private float MaxPanAngle = 0f;
    [SerializeField] private float MinPanAngle = 540f;

    [SerializeField] private float MaxTiltAngle = -45f;
    [SerializeField] private float MinTiltAngle = -45f + 270f;

    private int _panChannel;
    private int _tiltChannel;
    private int _intensityChannel;
    private int _redChannel;
    private int _greenChannel;
    private int _blueChannel;
    private int _whiteChannel;
    #endregion
    private float _p = 0f;
    private float _t = 0f;
    private float _r = 0f;
    private float _g = 0f;
    private float _b = 0f;
    private float _w = 0f;
    private float _i = 0f;
    [SerializeField]
    private Color _color = Color.black;
    // materialPropertyBlock
    [SerializeField] private MaterialPropertyBlock materialPropertyBlock = null;

    void Update()
    {
        UpdateFixture();
    }

    void CheckDMXChannel()
    {
        if (artNetChannels == null)
        {
            artNetChannels = GameObject.Find("LightConsole").GetComponent<DMXChannel>();
        }
    }

    public void UpdateFixture()
    {
        CheckDMXChannel();
        UpdateChannelMapping();
        GetChannelValues();
        UpdateColor();
        UpdateLight();
        UpdateRendererByPropatyBlock();
        UpdatePan();
        UpdateTilt();
    }

    private void GetChannelValues()
    {
        if(_Panpart != null)
        {
            _p = artNetChannels[_panChannel] / 255f;
        }
        if(_Tiltpart != null)
        {
            _t = artNetChannels[_tiltChannel] / 255f;
        }
        _r = artNetChannels[_redChannel] / 255f;
        _g = artNetChannels[_greenChannel] / 255f;
        _b = artNetChannels[_blueChannel] / 255f;
        _w = artNetChannels[_whiteChannel] / 255f;
        _i = artNetChannels[_intensityChannel] / 255f;
    }

    void UpdateLight()
    {
        if (lightToControl != null)
        {
            lightToControl.color = _color;
            lightToControl.intensity = _i * maxLightIntensity;
        }
    }

    private void UpdateColor()
    {
        _color = new Color(_r + _w, _g + _w, _b + _w, 1f);
    }

    void UpdateChannelMapping()
    {
        _panChannel = startAddress + panChannel - 1;
        _tiltChannel = startAddress + tiltChannel - 1;
        _intensityChannel = startAddress + intensityChannel - 1;
        _redChannel = startAddress + redChannel - 1;
        _greenChannel = startAddress + greenChannel - 1;
        _blueChannel = startAddress + blueChannel - 1;
        _whiteChannel = startAddress + whiteChannel - 1;
    }

    private void UpdateRendererByPropatyBlock()
    {
        if (targetRenderer != null)
        {
            if (materialPropertyBlock == null)
            {
                materialPropertyBlock = new MaterialPropertyBlock();
            }
            float rendererIntensity = _i * MaxRendererIntensity;
            targetRenderer.GetPropertyBlock(materialPropertyBlock);
            materialPropertyBlock.SetColor("_RGBColor", _color * rendererIntensity);
            materialPropertyBlock.SetFloat("_Brightness", rendererIntensity);
            targetRenderer.SetPropertyBlock(materialPropertyBlock);
        }
    }

    void UpdatePan()
    {
        if (_Panpart == null)
        {
            return;
        }
        float panAngle = _p;
        float panAngle2 = Mathf.Lerp(MinPanAngle, MaxPanAngle, panAngle);
        Vector3 panRotationVector = GetRotationVector(panRotationAxis, panAngle2);
        Quaternion panRotation = Quaternion.Euler(panRotationVector);
        panOrientationAverage = Quaternion.Lerp(panOrientationAverage, panRotation, lightSmoothness);
        _Panpart.localRotation = panOrientationAverage;
    }

    void UpdateTilt()
    {
        if (_Tiltpart == null)
        {
            return;
        }
        float tiltAngle = _t;
        float tiltAngle2 = Mathf.Lerp(MinTiltAngle, MaxTiltAngle, tiltAngle);
        Vector3 tiltRotationVector = GetRotationVector(tiltRotationAxis, tiltAngle2);
        Quaternion tiltRotation = Quaternion.Euler(tiltRotationVector);
        tiltOrientationAverage = Quaternion.Lerp(tiltOrientationAverage, tiltRotation, lightSmoothness);
        _Tiltpart.localRotation = tiltOrientationAverage;
    }

    private Vector3 GetRotationVector(MovingRotationAxis axis, float angle)
    {
        switch (axis)
        {
            case MovingRotationAxis.X:
                return new Vector3(angle, 0, 0);
            case MovingRotationAxis.Y:
                return new Vector3(0, angle, 0);
            case MovingRotationAxis.Z:
                return new Vector3(0, 0, angle);
            default:
                return Vector3.zero;
        }
    }
}
