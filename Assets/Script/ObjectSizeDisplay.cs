using UnityEngine;
using TMPro;

public class ObjectSizeDisplay : MonoBehaviour
{
    [SerializeField] private Transform targetObject; // **�T�C�Y��\������Ώۂ̃I�u�W�F�N�g**
    [SerializeField] private TextMeshProUGUI sizeText; // **TextMeshPro��UI�e�L�X�g**
    public float size = 0f;
    [SerializeField] private float correction = 15.1515f;

    private void Update()
    {
        if (targetObject != null && sizeText != null)
        {
            Vector3 scale = targetObject.localScale; // **�I�u�W�F�N�g�̃X�P�[�����擾**
            size = scale.x * correction;
            sizeText.text = $"{size:F1}"; // *s*�����_1���ŕ\��**
        }
    }
}
