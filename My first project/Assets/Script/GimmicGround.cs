using UnityEngine;
using GroundState;

namespace GroundState
{
    //지형 종류 분류
    public enum GroundType
    {
        nomal,
        slow,
        fast,
        jumpUP,
        jumpDown,
    }
}

public class GimmicGround : MonoBehaviour
{
    public GroundType groundType;
    [HideInInspector] public float groundSpeedValue = 1f;
    [HideInInspector] public float groundJumpValue = 1f;
    void Start()
    {
        Ground();
    }

    public void Ground()
    {
        //지형 효과 관련
        switch (groundType)
        {
            case GroundType.nomal:
                groundSpeedValue = 1f;
                groundJumpValue = 1f;
                break;

            case GroundType.fast:
                groundSpeedValue = 1.5f;
                groundJumpValue = 1f;
                break;

            case GroundType.slow:
                groundSpeedValue = 0.5f;
                groundJumpValue = 1f;
                break;

            case GroundType.jumpUP:
                groundSpeedValue = 1f;
                groundJumpValue = 1.5f;
                break;

            case GroundType.jumpDown:
                groundSpeedValue = 1f;
                groundJumpValue = 0.5f;
                break;

            default:
                groundSpeedValue = 1f;
                groundJumpValue = 1f;
                break;
        }
    }
}
