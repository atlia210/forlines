using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private float startTime = 10f; // **開始時間（秒）**
    [SerializeField] private TextMeshProUGUI timerText; // **TextMeshProのUIテキスト**

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
    /// タイマーを開始する（外部から呼び出し可能）
    /// </summary>
    public void StartTimer()
    {
        currentTime = startTime; // **カウントをリセット**
        isRunning = true;
        UpdateTimerUI();
    }

    /// <summary>
    /// **タイマーを停止する（外部から呼び出し可能）**
    /// </summary>
    public void StopTimer()
    {
        isRunning = false;
        Debug.Log("stop");
    }

    /// <summary>
    /// タイマーの処理（Update で呼び出し）
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
    /// タイマーの表示を更新
    /// </summary>
    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = currentTime.ToString("F1"); // **小数点第一位まで表示**
        }
    }

    /// <summary>
    /// タイマーが0になった時に呼び出す処理
    /// </summary>
    private void OnTimerEnd()
    {
        Debug.Log("タイマー終了！");
        gameController.bonusPoints.Clear();
        spawner.SpawnObjectsFromTriangleLayer();
    }
}
