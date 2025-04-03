using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update

    public float score = 0f;
    public List<float> bonusPoints = new List<float>();
    public float roundcount = 0f;
    public float bonusPoint = 1f;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator roundend()
    {
        yield return new WaitForSeconds(0.1f);
        bonusPoint = 1f;

        foreach (float point in bonusPoints)
        {
            bonusPoint *= point;
        }
    }
}
