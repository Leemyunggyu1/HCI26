
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class PlaceSphare : MonoBehaviour
{
    public GameObject SpherePrefab;
    public Camera arCamera;
    public Transform parentTransform;
    public ARRaycastManager raycastManager;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        var touchScreen = Touchscreen.current;
        if (touchScreen == null) return;

        if (!touchScreen.primaryTouch.press.wasPressedThisFrame)
            return;

        // UI 터치 확인
        if (EventSystem.current != null &&
            EventSystem.current.IsPointerOverGameObject(
                touchScreen.primaryTouch.touchId.ReadValue()))
            return;

        // 터치 위치 가져오기
        Vector2 screenPos =
            touchScreen.primaryTouch.position.ReadValue();

        // AR 평면 감지
        if (raycastManager == null) return;

        if (!raycastManager.Raycast(
            screenPos,
            hits,
            TrackableType.PlaneWithinPolygon))
            return;

        // 감지된 평면 위치에 Sphere 생성
        Vector3 worldPos = hits[0].pose.position;

        GameObject go = Instantiate(
            SpherePrefab,
            worldPos,
            Quaternion.identity
        );

        go.transform.parent = parentTransform;
    }
}
