using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{
    [SerializeField]
    GameObject xrOrigin;

    [SerializeField]
    Camera playerHead;

    [SerializeField]
    Transform resetTransform;

    private bool called = false;

    // Start is called before the first frame update
    void Start()
    {
       // ResetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (!called&& playerHead.transform.position.y > 0.2)
        {
            called = true;
            ResetPosition();
        }
    }

    [ContextMenu("Reset Position")]
    public void ResetPosition()
    {
        var rotationAngleY = resetTransform.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;
        xrOrigin.transform.Rotate(0, rotationAngleY, 0);

        var distanceDiff = resetTransform.position - playerHead.transform.position;
        Vector3 distance = new Vector3(distanceDiff.x, 0, distanceDiff.z);
        xrOrigin.transform.position += distance;
    }
}

