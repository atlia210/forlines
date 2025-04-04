using UnityEngine;
using TMPro;

public class DistanceDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText; // TMP��UI�e�L�X�g
    [SerializeField] private TextMeshProUGUI result;
    [SerializeField] private GameController gameController; // GameController �̎Q��
    [SerializeField] private ObjectSizeDisplay objectSizeDisplay;
    [SerializeField] private CountdownTimer timer;

    private void Update()
    {
        if (gameController.hitline)
        {
            result.text = $"(size+time)�~bonus";
            resultText.text = $"{objectSizeDisplay.size:F1}�@{timer.currentTime:F1}�@ �@{gameController.bonusPoint:F2}"; // �����_1���ŕ\��
        }
        else
        {
            result.text = $"size�~bonus+time";
            resultText.text = $"{objectSizeDisplay.size:F1}�@   {gameController.bonusPoint:F2}   �@{timer.currentTime:F1}"; // �����_1���ŕ\��
        }
    }
}
