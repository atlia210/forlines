using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineSpawner : MonoBehaviour
{
    public GameObject objectToClone; // Inspectorで指定するクローンするオブジェクト
    public Button spawnButton; // ボタンをInspectorで指定

    void Start()
    {
        if (spawnButton != null)
        {
            spawnButton.onClick.AddListener(SpawnObjectsFromTriangleLayer);
        }
    }

    void SpawnObjectsFromTriangleLayer()
    {
        GameObject[] triangleObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in triangleObjects)
        {
            if (obj.layer == LayerMask.NameToLayer("triangle")) // "triangle" Layer のオブジェクトを取得
            {
                Vector3 position = obj.transform.position;
                float rotationZ = obj.transform.rotation.eulerAngles.z;

                Instantiate(objectToClone, position, Quaternion.Euler(0, 0, rotationZ));
            }
        }
    }
}
