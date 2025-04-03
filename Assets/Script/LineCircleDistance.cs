using UnityEngine;

public class LineCircleDistance : MonoBehaviour
{
    [SerializeField] private GameObject circle; // 円のGameObjectを指定
    private GameController gameController;
    private int bonusPointIndex; // 自分のデータが入る bonusPoints のインデックス
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        circle = GameObject.FindWithTag("Player");
        gameController = FindObjectOfType<GameController>();

        if (gameController != null)
        {
            // 最初にリストへ 1 を追加し、自分のインデックスを記録
            gameController.bonusPoints.Add(1f);
            bonusPointIndex = gameController.bonusPoints.Count - 1;
        }
    }

    void Update()
    {
        if (gameController == null || circle == null) return;

        Collider2D lineCollider = GetComponent<Collider2D>();
        Vector2 circleCenter = circle.transform.position;
        float circleRadius = circle.transform.localScale.x / 2f; // 円のスケールから半径を取得

        // もっとも近い点を取得
        Vector2 closestPoint = lineCollider.ClosestPoint(circleCenter);

        // 線と円の距離を計算
        float distance = (circleCenter - closestPoint).magnitude - circleRadius;

        // 既存のリストの該当インデックスの値を更新
        float bonusValue = 1.5f - distance;
        if (bonusValue > 1.0f && bonusValue <=1.5f)
        {
            gameController.bonusPoints[bonusPointIndex] = bonusValue;
        }
        else if (bonusValue > 1.5f) 
        { 
            gameController.hitline = true;
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color32(210, 0, 0, 255); // 赤（RGBA）
        }
    }
}
