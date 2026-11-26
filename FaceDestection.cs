
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FaceDestection : MonoBehaviour
{
    public GameObject PositionCube;

    ARFaceManager afm;
    GameObject go;
    ARFace face = null;
    int index = 0;

    void Awake()
    {
        afm = GetComponent<ARFaceManager>();
        go = Instantiate(PositionCube, transform.position, transform.rotation);
        go.SetActive(false);

        afm.trackablesChanged.AddListener(args =>
        {
            foreach (var f in args.added) face = f;

            foreach (var kf in args.removed)
                if (kf.Value == face) face = null;
        });
    }

    public void OnClick()
    {
        if (face == null) return;
        if (face.vertices.Length == 0) return;

        go.SetActive(true);
        go.transform.position =
            face.transform.TransformPoint(face.vertices[index]);

        index++;
        if (index >= face.vertices.Length) index = 0;
    }
}
