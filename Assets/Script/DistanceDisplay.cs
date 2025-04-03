using UnityEngine;
using TMPro;

public class DistanceDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceText; // TMP��UI�e�L�X�g
    [SerializeField] private GameController gameController; // GameController �̎Q��

    private void Update()
    {
        if (distanceText != null && gameController != null)
        {
            distanceText.text = $"Bonus: {gameController.bonusPoint:F1}"; // �����_1���ŕ\��
        }
    }
}
