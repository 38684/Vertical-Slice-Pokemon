using UnityEngine;

public class BattleCameraController : MonoBehaviour
{
    [Header("References")]
    public Transform pivot;       // The pivot the camera rotates around
    public Transform cam;         // The actual Main Camera
    public Transform playerMon;   // Player Pokémon
    public Transform enemyMon;    // Enemy Pokémon

    [Header("General Camera Settings")]
    public float followSmooth = 4f;
    public float baseDistance = 8f;
    public float baseHeight = 3f;
    public float tiltDownAngle = 15f;

    [Header("Dynamic Motion")]
    public float rotateSpeed = 20f;
    public float idleRotateAmount = 10f;  // slow idle movement
    public float idleRotateSpeed = 0.5f;

    [Header("Attack Camera Settings")]
    public float attackZoomDistance = 5f;
    public float attackHeight = 2f;
    public float attackTilt = 10f;
    public float attackLerp = 6f;

    bool inAttackMode = false;
    float attackTimer = 0f;
    float attackDuration = 1.25f;

    void LateUpdate()
    {
        if (!enabled) return;

        if (playerMon == null || enemyMon == null) return;

        // 1. Follow midpoint between both Pokémon
        Vector3 midpoint = (playerMon.position + enemyMon.position) * 0.5f;
        transform.position = Vector3.Lerp(transform.position, midpoint, Time.deltaTime * followSmooth);

        // 2. Idle rotation (Sword/Shield floating camera feel)
        float idleRotation = Mathf.Sin(Time.time * idleRotateSpeed) * idleRotateAmount;
        pivot.localRotation = Quaternion.Euler(tiltDownAngle, idleRotation, 0f);

        // 3. Camera offset configuration
        float targetDistance = inAttackMode ? attackZoomDistance : baseDistance;
        float targetHeight = inAttackMode ? attackHeight : baseHeight;

        Vector3 desiredLocalPos = new Vector3(0, targetHeight, -targetDistance);
        float lerpSpeed = inAttackMode ? attackLerp : followSmooth;

        cam.localPosition = Vector3.Lerp(cam.localPosition, desiredLocalPos, Time.deltaTime * lerpSpeed);

        // 4. Handle attack transition timing
        if (inAttackMode)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackDuration)
                EndAttackCamera();
        }
    }

    // Call this when a move animation begins
    public void TriggerAttackCamera()
    {
        inAttackMode = true;
        attackTimer = 0f;
        pivot.localRotation = Quaternion.Euler(attackTilt, pivot.localEulerAngles.y, 0);
    }

    // Automatically resets after attack
    void EndAttackCamera()
    {
        inAttackMode = false;
    }
}
