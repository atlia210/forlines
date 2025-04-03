using UnityEngine;

public class LineCircleDistance : MonoBehaviour
{
    [SerializeField] private GameObject circle; // �~��GameObject���w��
    private GameController gameController;
    private int bonusPointIndex; // �����̃f�[�^������ bonusPoints �̃C���f�b�N�X
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        circle = GameObject.FindWithTag("Player");
        gameController = FindObjectOfType<GameController>();

        if (gameController != null)
        {
            // �ŏ��Ƀ��X�g�� 1 ��ǉ����A�����̃C���f�b�N�X���L�^
            gameController.bonusPoints.Add(1f);
            bonusPointIndex = gameController.bonusPoints.Count - 1;
        }
    }

    void Update()
    {
        if (gameController == null || circle == null) return;

        Collider2D lineCollider = GetComponent<Collider2D>();
        Vector2 circleCenter = circle.transform.position;
        float circleRadius = circle.transform.localScale.x / 2f; // �~�̃X�P�[�����甼�a���擾

        // �����Ƃ��߂��_���擾
        Vector2 closestPoint = lineCollider.ClosestPoint(circleCenter);

        // ���Ɖ~�̋������v�Z
        float distance = (circleCenter - closestPoint).magnitude - circleRadius;

        // �����̃��X�g�̊Y���C���f�b�N�X�̒l���X�V
        float bonusValue = 1.5f - distance;
        if (bonusValue > 1.0f && bonusValue <=1.5f)
        {
            gameController.bonusPoints[bonusPointIndex] = bonusValue;
        }
        else if (bonusValue > 1.5f) 
        { 
            gameController.hitline = true;
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color32(210, 0, 0, 255); // �ԁiRGBA�j
        }
    }
}
