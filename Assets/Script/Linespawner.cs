using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineSpawner : MonoBehaviour
{
    public GameObject objectToClone; // Inspectorで指定するクローンするオブジェクト
    public Button spawnButton; // ボタンをInspectorで指定
    [SerializeField] Button startbotton;

    [SerializeField] private GameController gameController;
    [SerializeField] private CountdownTimer timer;

    void Start()
    {
        if (spawnButton != null)
        {
            gameController.bonusPoints.Clear();
            spawnButton.onClick.AddListener(SpawnObjectsFromTriangleLayer);
        }
    }

    public void SpawnObjectsFromTriangleLayer()//lineをclone
    {
        timer.StopTimer();
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
        gameController.StartCoroutine(gameController.roundend());
        spawnButton.gameObject.SetActive(false);
        startbotton.gameObject.SetActive(true);
    }
}
