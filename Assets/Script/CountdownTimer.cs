using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private float startTime = 10f; // **�J�n���ԁi�b�j**
    [SerializeField] private TextMeshProUGUI timerText; // **TextMeshPro��UI�e�L�X�g**

    [SerializeField] private GameController gameController;
    [SerializeField] private LineSpawner spawner;

    public float currentTime;
    public bool isRunning = false;

    private void Update()
    {
        if (isRunning)
        {
            RunTimer();
        }
    }

    /// <summary>
    /// �^�C�}�[���J�n����i�O������Ăяo���\�j
    /// </summary>
    public void StartTimer()
    {
        currentTime = startTime; // **�J�E���g�����Z�b�g**
        isRunning = true;
        UpdateTimerUI();
    }

    /// <summary>
    /// **�^�C�}�[���~����i�O������Ăяo���\�j**
    /// </summary>
    public void StopTimer()
    {
        isRunning = false;
        Debug.Log("stop");
    }

    /// <summary>
    /// �^�C�}�[�̏����iUpdate �ŌĂяo���j
    /// </summary>
    private void RunTimer()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0f)
        {
            currentTime = 0f;
            isRunning = false;
            OnTimerEnd();
        }
        UpdateTimerUI();
    }

    /// <summary>
    /// �^�C�}�[�̕\�����X�V
    /// </summary>
    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = currentTime.ToString("F1"); // **�����_���ʂ܂ŕ\��**
        }
    }

    /// <summary>
    /// �^�C�}�[��0�ɂȂ������ɌĂяo������
    /// </summary>
    private void OnTimerEnd()
    {
        Debug.Log("�^�C�}�[�I���I");
        gameController.bonusPoints.Clear();
        spawner.SpawnObjectsFromTriangleLayer();
    }
}
