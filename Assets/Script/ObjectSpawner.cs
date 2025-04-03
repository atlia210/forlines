using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToClone; // Inspectorで指定するゲームオブジェクト
    public Button spawnButton; // ボタンをInspectorで指定
    [SerializeField] int n;
    [SerializeField] int addrotmin = -15;
    [SerializeField] int addrotmax = 15;
    [SerializeField] CountdownTimer timer;
    [SerializeField] Circle circle;

    [SerializeField] private GameController gameController;

    [SerializeField] List<int> generatedNumbers = new List<int>();

    void Start()
    {
        if (spawnButton != null)
        {
            spawnButton.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        circle.dragable = true;
        gameController.isgame = true;
        DestroyLineLayerObjects();
        generatedNumbers.Clear(); // リストをリセット
        SpawnObject();
        timer.StartTimer();
        gameController.currentround += 1;
        gameController.hitline = false;

        gameController.bonusPoints.Clear();//ボーナスをリセット
        gameController.bonusPoint = 1f;
        
    }

    void SpawnObject()
    {
        for (int a = 0; a < n; a++)
        {
            int i = GenerateValidRandomNumber();
            generatedNumbers.Add(i);

            Vector2 spawnPosition;
            float rotationZ = 0;

            if (i <= 108)
            {
                spawnPosition = new Vector2(-9.6f, (i - 54) / 10f);
                rotationZ = (-60 * i / 108f) - 60f;
            }
            else if (i <= 300)
            {
                spawnPosition = new Vector2((i - 108 - 96) / 10f, 5.4f);
                rotationZ = (-120 * (i - 108) / (300 - 108)) - 120f;
            }
            else if (i <= 408)
            {
                spawnPosition = new Vector2(9.6f, -(i - 300 - 54) / 10f);
                rotationZ = (-60 * (i - 300) / (408 - 300)) - 240f;
            }
            else
            {
                spawnPosition = new Vector2(-(i - 408 - 96) / 10f, -5.4f);
                rotationZ = (-120 * (i - 408) / (600 - 408)) - 300f;
            }
            int addrot = Random.Range(addrotmin, addrotmax);
            GameObject clone = Instantiate(objectToClone, spawnPosition, Quaternion.Euler(0, 0, rotationZ+addrot));
        }
    }

    int GenerateValidRandomNumber()
    {
        int i;
        bool isValid;
        do
        {
            i = Random.Range(0, 601);
            isValid = true;

            // 区間ごとのカウント
            int sameRangeCount = 0;
            foreach (int num in generatedNumbers)
            {
                if (GetRange(num) == GetRange(i))
                {
                    sameRangeCount++;
                    if (sameRangeCount >= 3)
                    {
                        isValid = false;
                        break;
                    }
                }
                if (Mathf.Abs(num - i) <= 30)
                {
                    isValid = false;
                    break;
                }
            }
        } while (!isValid || !CheckValidNumber(i));

        return i;
    }

    bool CheckValidNumber(int i)
    {
        int sameRangeCount = 0;
        foreach (int num in generatedNumbers)
        {
            if (GetRange(num) == GetRange(i))
            {
                sameRangeCount++;
                if (sameRangeCount >= 3)
                {
                    return false;
                }
            }
            if (Mathf.Abs(num - i) <= 10)
            {
                return false;
            }
        }
        return true;
    }

    int GetRange(int i)
    {
        if (i <= 108) return 0;
        if (i >= 109 & i <= 300) return 1;
        if (i <= 300 & i <= 408) return 2;
        return 3;
    }

    void DestroyLineLayerObjects()
    {
        GameObject[] lineObjects = GameObject.FindGameObjectsWithTag("line");
        foreach (GameObject obj in lineObjects)
        {
            Destroy(obj);
        }
    }
}
