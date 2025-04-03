using UnityEngine;
using TMPro;

public class DistanceDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceText; // TMPのUIテキスト
    [SerializeField] private GameController gameController; // GameController の参照
    [SerializeField] private ObjectSizeDisplay objectSizeDisplay;
    [SerializeField] private CountdownTimer timer;

    private void Update()
    {
        if (distanceText != null && gameController != null)
        {
            distanceText.text = $"{objectSizeDisplay.size:F1}　 {gameController.bonusPoint:F2}　 {timer.currentTime:F1}"; // 小数点1桁で表示
        }
    }
}
