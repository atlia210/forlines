using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public GameObject targetObject; // DragAndScaleをアタッチしたオブジェクト
    public TextMeshProUGUI scaleText; // スケール表示用のUIテキスト
    public List<Button> startButtons; // タイマー開始ボタンリスト
    public List<Button> stopButtons; // タイマー停止ボタンリスト

    private float timer = 0f; // タイマーの現在値
    private bool isTiming = false; // タイマーが動いているか

    void Start()
    {
        // ボタンのリスナー設定
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
            timer += Time.deltaTime; // タイマーを進める
        }
    }

    // タイマーのカウントをリセットし、開始する
    private void StartTimer()
    {
        timer = 0f;
        isTiming = true;
    }

    // タイマーを停止する
    private void StopTimer()
    {
        isTiming = false;
    }
}
