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
    }
}

public class GimmicGround : MonoBehaviour
{
    private PlayerManager player;
    public GroundType groundType;

    private void OnCollisionStay2D(Collision2D collison) {   
        player = collison.gameObject.GetComponent<PlayerManager>();

        if(player != null)
        {
            player.gimmicGround = this;
        }
   }
}
