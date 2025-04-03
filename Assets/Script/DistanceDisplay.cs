using UnityEngine;
using TMPro;

public class DistanceDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceText; // TMPのUIテキスト
    [SerializeField] private GameController gameController; // GameController の参照

    private void Update()
    {
        if (distanceText != null && gameController != null)
        {
            distanceText.text = $"Bonus: {gameController.bonusPoint:F1}"; // 小数点1桁で表示
        }
    }
}
