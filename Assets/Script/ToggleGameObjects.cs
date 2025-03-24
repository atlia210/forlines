using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ToggleGameObjects : MonoBehaviour
{
    // 表示・非表示を切り替えるGameObjectリスト
    public List<GameObject> targetObjects;
    public List<Button> hideButtons;
    public Button showButton;

    void Start()
    {
        // 表示ボタンの設定
        if (showButton != null)
        {
            showButton.onClick.AddListener(ShowObjects);
            showButton.onClick.AddListener(HideLineLayerObjects);
        }

        // 非表示ボタンの設定
        foreach (Button btn in hideButtons)
        {
            if (btn != null)
            {
                btn.onClick.AddListener(HideObjects);
            }
        }
    }

    // 指定したオブジェクトを表示する
    public void ShowObjects()
    {
        foreach (GameObject obj in targetObjects)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }

    // 指定したオブジェクトを非表示にする
    public void HideObjects()
    {
        foreach (GameObject obj in targetObjects)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }

    // "line"レイヤーのオブジェクトをすべて非表示にする
    public void HideLineLayerObjects()
    {
        int lineLayer = LayerMask.NameToLayer("line");
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.layer == lineLayer)
            {
                obj.SetActive(false);
            }
        }
    }
}
