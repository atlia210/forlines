using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShowLineLayerObjects : MonoBehaviour
{
    public Button showLineButton;
    public List<GameObject> lineObjects;

    void Start()
    {
        if (showLineButton != null)
        {
            showLineButton.onClick.AddListener(ShowLineObjects);
        }
    }

    // Inspectorで指定した"line"レイヤーのオブジェクトを表示する
    public void ShowLineObjects()
    {
        foreach (GameObject obj in lineObjects)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
