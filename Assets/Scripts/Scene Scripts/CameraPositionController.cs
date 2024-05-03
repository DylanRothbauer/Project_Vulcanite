using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionController : MonoBehaviour
{
    // Start is called before the first frame update
    public float LeftBound = -7.5f;
    public float RightBound = 7.5f;
    public float BottomBound = -1.4f;
    public GameObject player;
    private Vector3 cameraUpdater;

    void Start()
    {
        cameraUpdater = player.transform.position;
        cameraUpdater.z = -10;
        if (player.transform.position.x < LeftBound) { cameraUpdater.x = LeftBound; }
        else if (player.transform.position.x > RightBound) { cameraUpdater.x = RightBound; }
        if (player.transform.position.y < BottomBound) { cameraUpdater.y = BottomBound; }
        transform.position = cameraUpdater;
    }

    // Update is called once per frame
    void Update()
    {
        cameraUpdater.x = player.transform.position.x;
        cameraUpdater.y = player.transform.position.y;
        if (player.transform.position.x < LeftBound) { cameraUpdater.x = LeftBound; }
        else if (player.transform.position.x > RightBound) { cameraUpdater.x = RightBound; }
        if (player.transform.position.y < BottomBound) { cameraUpdater.y = BottomBound; }
        transform.position = cameraUpdater;
    }
}
