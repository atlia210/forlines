using UnityEngine;
using TMPro;

public class ObjectSizeDisplay : MonoBehaviour
{
    [SerializeField] private Transform targetObject; // **サイズを表示する対象のオブジェクト**
    [SerializeField] private TextMeshProUGUI sizeText; // **TextMeshProのUIテキスト**

    private void Update()
    {
        if (targetObject != null && sizeText != null)
        {
            Vector3 scale = targetObject.localScale; // **オブジェクトのスケールを取得**
            sizeText.text = $"{scale.x*15.1515:F0}"; // *s*小数点1桁で表示**
        }
    }
}
