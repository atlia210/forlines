using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Circle : MonoBehaviour
{
    public bool dragable = true;
    public Vector2 center = Vector2.zero; // ���E�~�̒��S
    public float radius = 5f; // ���E�~�̔��a

    [SerializeField] private float minSize = 0.5f; // �ŏ��T�C�Y
    [SerializeField] private float maxSize = 3f;   // �ő�T�C�Y
    [SerializeField] private float scaleSpeed = 0.1f; // �g�k���x

    private Vector2 error;
    private Rigidbody2D rb;
    private bool isDragging = false;
    private Vector2 targetPos; // �ʒu��ۑ�

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

        rb.velocity = Vector2.zero; // �����𖳌���

        targetPos = error + (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos = ClampPosition(targetPos); // **�ʒu������K�p**
        rb.MovePosition(targetPos);
    }

    private void Update()
    {
        if (!dragable) return;

        // **�}�E�X�z�C�[���ɂ��g�k����**
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            float newScale = Mathf.Clamp(transform.localScale.x + scroll * scaleSpeed, minSize, maxSize);
            transform.localScale = new Vector3(newScale, newScale, 1f);

            // **�g�k��Ɉʒu���Ē���**
            targetPos = ClampPosition(transform.position);
            rb.MovePosition(targetPos);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    /// <summary>
    /// �w�肵�����W�����E�~���Ɏ��߂�
    /// </summary>
    private Vector2 ClampPosition(Vector2 pos)
    {
        Vector2 direction = pos - center; // ���S����̃x�N�g��
        float objectRadius = transform.localScale.x / 2; // **�I�u�W�F�N�g�̔��a**
        float adjustedRadius = radius - objectRadius; // **���E�~�̒����㔼�a**

        if (direction.magnitude > adjustedRadius)
        {
            return center + direction.normalized * adjustedRadius; // ���E���ɏC��
        }
        return pos;
    }
}
