using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIdeGameObjects : MonoBehaviour
{
    // インスペクターから設定できるGameObjectのリスト
    public List<GameObject> objectsToHide;

    // 指定したオブジェクトを非表示にするメソッド
    void Start()
    {
        foreach (GameObject obj in objectsToHide)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }
}
