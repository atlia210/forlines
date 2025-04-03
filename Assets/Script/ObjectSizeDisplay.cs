using UnityEngine;
using TMPro;

public class ObjectSizeDisplay : MonoBehaviour
{
    [SerializeField] private Transform targetObject; // **�T�C�Y��\������Ώۂ̃I�u�W�F�N�g**
    [SerializeField] private TextMeshProUGUI sizeText; // **TextMeshPro��UI�e�L�X�g**

    private void Update()
    {
        if (targetObject != null && sizeText != null)
        {
            Vector3 scale = targetObject.localScale; // **�I�u�W�F�N�g�̃X�P�[�����擾**
            sizeText.text = $"{scale.x*15.1515:F0}"; // *s*�����_1���ŕ\��**
        }
    }
}
