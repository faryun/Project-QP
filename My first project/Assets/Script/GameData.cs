using System;

[Serializable] // 직렬화

public class Data
{
    // 각 챕터의 잠금여부를 저장할 배열
    public bool[] isUnlock = new bool[8];

    // 각 챕터의 클리어 시간을 저장할 배열
    public float[] time = new float[8];

    // 현재 레벨
    public int currentLevel = 0;
}