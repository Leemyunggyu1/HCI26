using UnityEngine;

public class PlaceSphare : MonoBehaviour
{
    public GameObject SpherePrefab;
    public Camera arCamera;
    public Transform parentTransform;

    void Update()
    {
        int touchCount = Input.touchCount;
        if (touchCount < 1) return;

        Touch touch = Input.GetTouch(0);

        Vector3 touchPosition = arCamera.ScreenToWorldPoint(
            new Vector3(
                touch.position.x,
                touch.position.y,
                0.5f
            )
        );

        if (touch.phase == TouchPhase.Began)
        {
            GameObject go = Instantiate(
                SpherePrefab,
                touchPosition,
                Quaternion.identity
            );

            go.transform.parent = parentTransform;
            go.transform.position = touchPosition;
        }
    }
}