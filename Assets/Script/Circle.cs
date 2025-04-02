using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Circle : MonoBehaviour
{
    public bool dragable = true;
    public Vector2 center = Vector2.zero; // 境界円の中心
    public float radius = 5f; // 境界円の半径

    [SerializeField] private float minSize = 0.5f; // 最小サイズ
    [SerializeField] private float maxSize = 3f;   // 最大サイズ
    [SerializeField] private float scaleSpeed = 0.1f; // 拡縮速度

    private Vector2 error;
    private Rigidbody2D rb;
    private bool isDragging = false;
    private Vector2 targetPos; // 位置を保存

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        error = (Vector2)transform.position - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (!dragable || rb == null) return;

        rb.velocity = Vector2.zero; // 慣性を無効化

        targetPos = error + (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos = ClampPosition(targetPos); // **位置調整を適用**
        rb.MovePosition(targetPos);
    }

    private void Update()
    {
        if (!dragable) return;

        // **マウスホイールによる拡縮処理**
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            float newScale = Mathf.Clamp(transform.localScale.x + scroll * scaleSpeed, minSize, maxSize);
            transform.localScale = new Vector3(newScale, newScale, 1f);

            // **拡縮後に位置を再調整**
            targetPos = ClampPosition(transform.position);
            rb.MovePosition(targetPos);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    /// <summary>
    /// 指定した座標を境界円内に収める
    /// </summary>
    private Vector2 ClampPosition(Vector2 pos)
    {
        Vector2 direction = pos - center; // 中心からのベクトル
        float objectRadius = transform.localScale.x / 2; // **オブジェクトの半径**
        float adjustedRadius = radius - objectRadius; // **境界円の調整後半径**

        if (direction.magnitude > adjustedRadius)
        {
            return center + direction.normalized * adjustedRadius; // 境界内に修正
        }
        return pos;
    }
}
