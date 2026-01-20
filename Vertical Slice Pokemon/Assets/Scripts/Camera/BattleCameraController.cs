using UnityEngine;

public class BattleCamera : MonoBehaviour
{
    public Transform player;
    public Transform enemy;
    public bool isAttackCamera;

    [SerializeField] private Vector3 shoulderOffset = new Vector3(2f, 1.5f, -3f);
    public Vector3 attackOffset = new Vector3(0f, 2f, -4f);
    [SerializeField] private float followSpeed = 2f;
    [SerializeField] private float shakeIntensity = 0.1f;

    private Vector3 _currentVelocity;
    private float _timeOffset;

    private void Awake()
    {
        _timeOffset = Random.Range(0f, 100f);
    }

    private void LateUpdate()
    {
        if (player == null) return;

        var targetPosition = GetTargetPosition();
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, 1f / followSpeed);

        var lookTarget = GetLookTarget();
        var targetRotation = Quaternion.LookRotation(lookTarget - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * followSpeed);
    }

    private Vector3 GetTargetPosition()
    {
        Vector3 basePosition;

        if (isAttackCamera)
        {
            var midpoint = (player.position + enemy.position) * 0.5f;
            basePosition = midpoint + attackOffset;
        }
        else
        {
            basePosition = player.position + player.TransformDirection(shoulderOffset);
        }

        var shake = GetShakeOffset();
        return basePosition + shake;
    }

    private Vector3 GetLookTarget()
    {
        if (isAttackCamera && enemy != null)
        {
            return (player.position + enemy.position) * 0.5f;
        }

        return player.position + player.forward * 5f;
    }

    private Vector3 GetShakeOffset()
    {
        var time = Time.time + _timeOffset;
        var x = Mathf.PerlinNoise(time, 0f) * 2f - 1f;
        var y = Mathf.PerlinNoise(0f, time) * 2f - 1f;
        var z = Mathf.PerlinNoise(time * 0.5f, time * 0.7f) * 2f - 1f;

        return new Vector3(x, y, z) * shakeIntensity;
    }
}