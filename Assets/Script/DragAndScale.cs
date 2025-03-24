using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndScale : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCamera;
    private bool isDragging = false;
    public float scaleSpeed = 0.1f;
    public float minScale = 0.5f;
    public float maxScale = 3f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        // �N���b�N���ɃI�t�Z�b�g���v�Z
        offset = transform.position - GetMouseWorldPos();
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            // �I�u�W�F�N�g���}�E�X�̈ʒu�ɒǏ]������
            transform.position = GetMouseWorldPos() + offset;
        }

        // �}�E�X�z�C�[���ŃX�P�[���ύX
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            float scaleChange = 1 + scroll * scaleSpeed;
            Vector3 newScale = transform.localScale * scaleChange;
            newScale = Vector3.Max(Vector3.one * minScale, Vector3.Min(Vector3.one * maxScale, newScale));
            transform.localScale = newScale;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mainCamera.WorldToScreenPoint(transform.position).z;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}
