using UnityEngine;

public class CameraPositions : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    private void Start()
    {
        MoveCamera(pos1);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MoveCamera(pos1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MoveCamera(pos2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MoveCamera(pos3);
        }
    }

    void MoveCamera(Transform targetPos)
    {
        transform.position = targetPos.position;
        transform.rotation = targetPos.rotation;
    }
}