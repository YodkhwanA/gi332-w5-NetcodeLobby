using UnityEngine;
using Unity.Netcode;

public abstract class Coin : NetworkBehaviour
{ //เขียนแบบนี้เพื่อให้คลาสลูกสามารถใช้งานกับคลาสอื่นๆต่อได้
    [SerializeField] private SpriteRenderer spriteRenderer;

    protected int coinValue = 10;

    protected bool alreadyCollected;

    public abstract int Collect();

    public void SetValue(int value)
    {
        coinValue = value;
    }

    //main core coin
    protected void Show(bool show)
    {
        spriteRenderer.enabled = show;
    }
}


