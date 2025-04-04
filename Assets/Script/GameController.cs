using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float score = 0f;
    public float maxscore = 0f;
    public float totalscore = 0f;
    public List<float> scoreList = new List<float>();
    public List<float> bonusPoints = new List<float>();
    public int roundcount = 0;
    public int currentround = 0;
    public float bonusPoint = 1f;
    public bool isgame = true;
    public bool hitline = false;
    [SerializeField] private int MaxScoreHistory = 10;

    [SerializeField] private Circle circle;
    [SerializeField] private CountdownTimer timer;
    [SerializeField] private TextMeshProUGUI roundText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI startbottonText;
    [SerializeField] private TextMeshProUGUI scoreHistoryText; // �X�R�A����\���p
    [SerializeField] private TextMeshProUGUI scoreAveText; // ���σX�R�A�\���p
    [SerializeField] private List<GameObject> activeWhenGameOn = new List<GameObject>(); // isgame = true�̂Ƃ��ɕ\������I�u�W�F�N�g
    [SerializeField] private List<GameObject> activeWhenGameOff = new List<GameObject>(); // isgame = false�̂Ƃ��ɕ\������I�u�W�F�N�g

    [SerializeField] private ObjectSizeDisplay objectSizeDisplay;

    void Start()
    {
        UpdateGameObjectVisibility();
    }

    void Update()
    {
        UpdateGameObjectVisibility();
        roundText.text = $"{currentround}";

        if (currentround == 0)
        {
            startbottonText.text = $"start";
        }
        else
        {
            startbottonText.text = $"next";
        }
    }

    public IEnumerator roundend()
    {
        circle.dragable = false;
        yield return new WaitForSeconds(0.1f);
        bonusPoint = 1f;

        foreach (float point in bonusPoints)
        {
                bonusPoint *= point;
        }

        score = (objectSizeDisplay.size + timer.currentTime) * bonusPoint;
        scoreText.text = $"{score:F1}";

        if (score > maxscore)
        {
            maxscore = score;
        }
        totalscore += score;

        isgame = false;

        // �X�R�A�����X�g�ɒǉ� & �ŐV10�����ێ�
        if (scoreList.Count >= MaxScoreHistory)
        {
            scoreList.RemoveAt(0); // ��ԌÂ��f�[�^���폜
        }
        scoreList.Add(score);

        UpdateScoreHistoryUI();



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

    private void UpdateScoreHistoryUI()
    {
        scoreHistoryText.text = "";
        for (int i = 0; i < scoreList.Count; i++)
        {
            scoreHistoryText.text += $"    R{currentround - scoreList.Count + i + 1}: {scoreList[i]:F1}\n";
        }
        scoreAveText.text = $"average: {totalscore/currentround:F1}\n       max: {maxscore:F1} ";
    }
}
