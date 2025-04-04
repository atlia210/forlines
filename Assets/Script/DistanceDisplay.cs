using UnityEngine;
using TMPro;

public class DistanceDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText; // TMPのUIテキスト
    [SerializeField] private TextMeshProUGUI result;
    [SerializeField] private GameController gameController; // GameController の参照
    [SerializeField] private ObjectSizeDisplay objectSizeDisplay;
    [SerializeField] private CountdownTimer timer;

    private void Update()
    {
        if (gameController.hitline)
        {
            result.text = $"(size+time)×bonus";
            resultText.text = $"{objectSizeDisplay.size:F1}　{timer.currentTime:F1}　 　{gameController.bonusPoint:F2}"; // 小数点1桁で表示
        }
        else
        {
            result.text = $"size×bonus+time";
            resultText.text = $"{objectSizeDisplay.size:F1}　   {gameController.bonusPoint:F2}   　{timer.currentTime:F1}"; // 小数点1桁で表示
        }
    }
}
