using UnityEngine;

public class CatchCameraTester : MonoBehaviour
{
    public CaptureCameraController captureCam;
    public Transform testBall;

    void Update()
    {
        // Press C to trigger the catch camera
        if (Input.GetKeyDown(KeyCode.C))
        {
            captureCam.StartCapture(testBall);
        }
    }
}
