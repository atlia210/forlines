using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float score = 0f;
    public float totalscore = 0f;
    public List<float> bonusPoints = new List<float>();
    public int roundcount = 0;
    public int currentround = 0;
    public float bonusPoint = 1f;
    public bool isgame = true;
    public bool hitline = false;

    [SerializeField] private Circle circle;
    [SerializeField] private CountdownTimer timer;
    [SerializeField] private TextMeshProUGUI roundText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private List<GameObject> activeWhenGameOn = new List<GameObject>(); // isgame = trueのときに表示するオブジェクト
    [SerializeField] private List<GameObject> activeWhenGameOff = new List<GameObject>(); // isgame = falseのときに表示するオブジェクト

    [SerializeField] private ObjectSizeDisplay objectSizeDisplay;

    void Start()
    {
        UpdateGameObjectVisibility();
    }

    void Update()
    {
        UpdateGameObjectVisibility();
        roundText.text = $"{currentround}";
    }

    public IEnumerator roundend()
    {
        circle.dragable = false;
        yield return new WaitForSeconds(0.1f);
        bonusPoint = 1f;

        if(hitline == false)
        {
            foreach (float point in bonusPoints)
            {
                bonusPoint *= point;
            }
        }
        else
        {
            bonusPoint *= 0.5f;
        }

        score = objectSizeDisplay.size * bonusPoint + timer.currentTime;
        scoreText.text = $"{score:F1}";
        isgame = false;
    }

    private void UpdateGameObjectVisibility()
    {
        foreach (GameObject obj in activeWhenGameOn)
        {
            if (obj != null) obj.SetActive(isgame);
        }

        foreach (GameObject obj in activeWhenGameOff)
        {
            if (obj != null) obj.SetActive(!isgame);
        }
    }
}
