using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public GameObject targetObject; // DragAndScale���A�^�b�`�����I�u�W�F�N�g
    public TextMeshProUGUI scaleText; // �X�P�[���\���p��UI�e�L�X�g
    public List<Button> startButtons; // �^�C�}�[�J�n�{�^�����X�g
    public List<Button> stopButtons; // �^�C�}�[��~�{�^�����X�g

    private float timer = 0f; // �^�C�}�[�̌��ݒl
    private bool isTiming = false; // �^�C�}�[�������Ă��邩

    void Start()
    {
        // �{�^���̃��X�i�[�ݒ�
        foreach (Button button in startButtons)
        {
            button.onClick.AddListener(StartTimer);
        }

        foreach (Button button in stopButtons)
        {
            button.onClick.AddListener(StopTimer);
        }
    }

    void Update()
    {
        if (targetObject != null && scaleText != null)
        {
            Vector3 scale = targetObject.transform.localScale;
            scaleText.text = $"Scale: {scale.x *40:F1}\nTimer: {timer:F2}";
        }

        if (isTiming)
        {
            timer += Time.deltaTime; // �^�C�}�[��i�߂�
        }
    }

    // �^�C�}�[�̃J�E���g�����Z�b�g���A�J�n����
    private void StartTimer()
    {
        timer = 0f;
        isTiming = true;
    }

    // �^�C�}�[���~����
    private void StopTimer()
    {
        isTiming = false;
    }
}
