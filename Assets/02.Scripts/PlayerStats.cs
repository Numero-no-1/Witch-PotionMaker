using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int playerLevel = 1;
    public int maxLevel = 10;
    public Text levelText;
    public int currentExp;
    public int baseExp = 100;
    public int[] expToLevelup;


    void Start()
    {
        levelText.text = "Level : " + playerLevel;
        expToLevelup = new int[maxLevel];
        expToLevelup[1] = baseExp;
        for(int i = 2; i < expToLevelup.Length; i++)
        {
            expToLevelup[i] = Mathf.FloorToInt(expToLevelup[i - 1] * 1.1f);            // 경험치 얼마 채워야 레벨업 되는지 자동으로 계산
;        }
    }

    
    void Update()
    {
        
    }
}
