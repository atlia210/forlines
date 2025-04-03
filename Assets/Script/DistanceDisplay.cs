using UnityEngine;
using TMPro;

public class DistanceDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceText; // TMP��UI�e�L�X�g
    [SerializeField] private GameController gameController; // GameController �̎Q��
    [SerializeField] private ObjectSizeDisplay objectSizeDisplay;
    [SerializeField] private CountdownTimer timer;

    private void Update()
    {
        if (distanceText != null && gameController != null)
        {
            distanceText.text = $"{objectSizeDisplay.size:F1}�@ {gameController.bonusPoint:F2}�@ {timer.currentTime:F1}"; // �����_1���ŕ\��
        }
    }
}
