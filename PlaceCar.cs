using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceCar : MonoBehaviour
{
    public GameObject marker;

    private ARRaycastManager arRayManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        // GetComponenet 오타 수정 및 컴포넌트 가져오기
        arRayManager = GetComponent<ARRaycastManager>();
        
        if (marker != null)
        {
            marker.SetActive(false);
        }
    }

    void Update()
    {
        DetectGround();
    }

    void DetectGround()
    {
        if (arRayManager == null) return;

        // 마이너스(-)를 대입 연산자(=)로 수정하고 변수명 통일
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

        hits.Clear();
        
        // if문 뒤에 실행 블록({}) 추가
        if (arRayManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon))
        {
            if (hits.Count > 0)
            {
                Pose hitPose = hits[0].pose;
                
                if (marker != null)
                {
                    marker.SetActive(true);
                    marker.transform.position = hitPose.position;
                    marker.transform.rotation = hitPose.rotation;
                }
            }
        }
        else
        {
            if (marker != null)
            {
                marker.SetActive(false);
            }
        }
    }
}