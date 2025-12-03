using UnityEngine;

public class CaptureCameraController : MonoBehaviour
{
    public BattleCameraController battleCam;
    public Transform playerMon;
    public Transform enemyMon;
    public Transform cam;

    [Header("Capture Camera Settings")]
    public float behindPlayerDistance = 2f;
    public float behindPlayerHeight = 1.2f;
    public float ballFollowSpeed = 6f;
    public float focusSpeed = 4f;
    public float shakeIntensity = 0.05f;
    public float shakeDuration = 1f;

    bool isCapturing = false;
    Transform ball;

    // Call this when the Poké Ball is thrown
    public void StartCapture(Transform pokeBall)
    {
        if (isCapturing) return;

        ball = pokeBall;
        isCapturing = true;

        // Disable the battle camera while capturing
        battleCam.enabled = false;
    }

    void LateUpdate()
    {
        if (!isCapturing) return;
        if (ball == null)
        {
            EndCapture();
            return;
        }

        // 1. Camera behind the player
        Vector3 behindPos =
            playerMon.position
            - playerMon.forward * behindPlayerDistance
            + Vector3.up * behindPlayerHeight;

        cam.position = Vector3.Lerp(cam.position, behindPos, Time.deltaTime * ballFollowSpeed);
        cam.LookAt(ball.position);

        // 2. When ball lands near enemy, trigger shake
        float distToEnemy = Vector3.Distance(ball.position, enemyMon.position);
        if (distToEnemy < 1.2f)
            StartCoroutine(ShakeAndFinish());
    }

    System.Collections.IEnumerator ShakeAndFinish()
    {
        float timer = 0f;

        while (timer < shakeDuration)
        {
            cam.position += Random.insideUnitSphere * shakeIntensity;
            timer += Time.deltaTime;
            yield return null;
        }

        EndCapture();
    }

    void EndCapture()
    {
        isCapturing = false;
        ball = null;

        // Re-enable the battle camera
        battleCam.enabled = true;
    }
}
