using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    public int maxHp;
    public int currrentHp;

    private void Start()
    {
        currrentHp = maxHp;
    }
    public void Damage(int dmaage)
    {
        currrentHp -= dmaage;
        if (currrentHp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}