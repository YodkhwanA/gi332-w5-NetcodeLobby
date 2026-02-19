using Unity.Netcode;
using UnityEngine;

public class CoinWallet : NetworkBehaviour
{
    public NetworkVariable<int> TotalCoins = new NetworkVariable<int>();

    public void SpendCoins(int costToFire)
    {
        TotalCoins.Value -= costToFire;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.TryGetComponent<Coin>(out Coin coin)) { return; }

        int coinValue = coin.Collect();

        if (!IsServer) { return; }

        TotalCoins.Value += coinValue;
    }
}


//เขียนเพื่อให้ผู้เล่นเก็บเหรียญได้ถ้า coin มี colider โดยจะมีเงื่อนไขว่าต้องเป็นใน server ถึงจะเก็บเหรียญเข้ากระเป๋าได้
//เรียนจะหายไปทั้ง server และ client แต่ค่าเหรียญจะเข้าที่ client
//ยิงแล้วเหรียญลดด้วย
