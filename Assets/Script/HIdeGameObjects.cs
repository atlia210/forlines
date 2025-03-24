using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIdeGameObjects : MonoBehaviour
{
    // �C���X�y�N�^�[����ݒ�ł���GameObject�̃��X�g
    public List<GameObject> objectsToHide;

    // �w�肵���I�u�W�F�N�g���\���ɂ��郁�\�b�h
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
