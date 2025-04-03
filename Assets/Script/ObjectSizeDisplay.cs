using UnityEngine;
using TMPro;

public class ObjectSizeDisplay : MonoBehaviour
{
    [SerializeField] private Transform targetObject; // **サイズを表示する対象のオブジェクト**
    [SerializeField] private TextMeshProUGUI sizeText; // **TextMeshProのUIテキスト**
    public float size = 0f;
    [SerializeField] private float correction = 15.1515f;

    private void Update()
    {
        if (targetObject != null && sizeText != null)
        {
            Vector3 scale = targetObject.localScale; // **オブジェクトのスケールを取得**
            size = scale.x * correction;
            sizeText.text = $"{size:F1}"; // *s*小数点1桁で表示**
        }
    }
}
