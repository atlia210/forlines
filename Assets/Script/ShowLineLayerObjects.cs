using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShowLineLayerObjects : MonoBehaviour
{
    public Button showLineButton;
    public List<GameObject> lineObjects;

    void Start()
    {
        if (showLineButton != null)
        {
            showLineButton.onClick.AddListener(ShowLineObjects);
        }
    }

    // Inspector�Ŏw�肵��"line"���C���[�̃I�u�W�F�N�g��\������
    public void ShowLineObjects()
    {
        foreach (GameObject obj in lineObjects)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
