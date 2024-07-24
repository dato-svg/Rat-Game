using UnityEngine;

public class GameSession : MonoBehaviour
{
    public PlayerData playerData;
    [SerializeField] private SpriteAnimation spriteAnimation;


    private void Start()
    {
        playerData = new PlayerData();
        playerData.Health = 100;
        
    }

    public void ChangeKeyState(bool hasKey)
    {
        playerData.Key = hasKey;
    }

    public void CheckKey()
    {
        if (playerData.Key)
        {
            spriteAnimation.enabled = true;
        }
    }
}


