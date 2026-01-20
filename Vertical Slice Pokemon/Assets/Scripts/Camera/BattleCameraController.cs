using UnityEngine;

public class BattleCameraController : MonoBehaviour
{
    [Header("References")]
    public Transform pivot;
    public Transform cam;
    public Transform playerMon;
    public Transform enemyMon;

    [Header("General Settings")]
    [Tooltip("How quickly the camera follows the midpoint")]
    public float followSmooth = 6f;

    public float baseDistance = 8f;
    public float baseHeight = 3f;

    [Tooltip("Default downward tilt of the camera")]
    public float baseTilt = 15f;

    [Header("Idle Motion")]
    [Tooltip("Max left/right rotation angle")]
    public float idleYawAmount = 10f;

    [Tooltip("Speed of idle rotation")]
    public float idleYawSpeed = 0.5f;

    [Header("Rotation Control")]
    [Tooltip("Global rotation strength (0 = none)")]
    public float rotationAmount = 1f;

    [Tooltip("Rotation strength during attacks")]
    public float attackRotationMultiplier = 0.5f;

    [Header("Attack Camera")]
    public float attackDistance = 5f;
    public float attackHeight = 2f;
    public float attackTilt = 10f;
    public float attackLerp = 6f;
    public float attackDuration = 1.25f;

    bool inAttackMode;
    float attackTimer;

    float currentTilt;
    float currentYaw;

    Vector3 followVelocity;

    void Start()
    {
        // Ensure inspector tilt changes are visible immediately
        currentTilt = baseTilt;
    }

    void LateUpdate()
    {
        if (!playerMon || !enemyMon) return;

        // 1️⃣ Follow midpoint using SmoothDamp (no jitter, real smoothing)
        Vector3 midpoint = (playerMon.position + enemyMon.position) * 0.5f;
        transform.position = Vector3.SmoothDamp(
            transform.position,
            midpoint,
            ref followVelocity,
            1f / followSmooth
        );

        // 2️⃣ Idle yaw with adjustable strength
        float yawStrength = inAttackMode ? attackRotationMultiplier : 1f;
        float idleYaw =
            Mathf.Sin(Time.time * idleYawSpeed) *
            idleYawAmount *
            rotationAmount *
            yawStrength;

        // 3️⃣ Tilt & yaw blending
        float targetTilt = inAttackMode ? attackTilt : baseTilt;

        currentTilt = Mathf.Lerp(currentTilt, targetTilt, Time.deltaTime * attackLerp);
        currentYaw = Mathf.Lerp(currentYaw, idleYaw, Time.deltaTime * followSmooth);

        pivot.localRotation = Quaternion.Euler(currentTilt, currentYaw, 0f);

        // 4️⃣ Camera offset
        float targetDistance = inAttackMode ? attackDistance : baseDistance;
        float targetHeight = inAttackMode ? attackHeight : baseHeight;

        Vector3 targetCamPos = new Vector3(0f, targetHeight, -targetDistance);
        cam.localPosition = Vector3.Lerp(
            cam.localPosition,
            targetCamPos,
            Time.deltaTime * attackLerp
        );

        // 5️⃣ Attack timer
        if (inAttackMode)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackDuration)
                EndAttackCamera();
        }
    }

    // Call when a move starts
    public void TriggerAttackCamera()
    {
        inAttackMode = true;
        attackTimer = 0f;
    }

    void EndAttackCamera()
    {
        inAttackMode = false;
    }
}
