using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ToggleGameObjects : MonoBehaviour
{
    // �\���E��\����؂�ւ���GameObject���X�g
    public List<GameObject> targetObjects;
    public List<Button> hideButtons;
    public Button showButton;

    void Start()
    {
        // �\���{�^���̐ݒ�
        if (showButton != null)
        {
            showButton.onClick.AddListener(ShowObjects);
            showButton.onClick.AddListener(HideLineLayerObjects);
        }

        // ��\���{�^���̐ݒ�
        foreach (Button btn in hideButtons)
        {
            if (btn != null)
            {
                btn.onClick.AddListener(HideObjects);
            }
        }
    }

    // �w�肵���I�u�W�F�N�g��\������
    public void ShowObjects()
    {
        foreach (GameObject obj in targetObjects)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }

    // �w�肵���I�u�W�F�N�g���\���ɂ���
    public void HideObjects()
    {
        foreach (GameObject obj in targetObjects)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }

    // "line"���C���[�̃I�u�W�F�N�g�����ׂĔ�\���ɂ���
    public void HideLineLayerObjects()
    {
        int lineLayer = LayerMask.NameToLayer("line");
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.layer == lineLayer)
            {
                obj.SetActive(false);
            }
        }
    }
}
