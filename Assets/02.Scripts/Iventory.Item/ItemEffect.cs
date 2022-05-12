using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템 효과 에셋화
public abstract class ItemEffect : ScriptableObject
{
    public abstract bool ExecuteRole();
}
