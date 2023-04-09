using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static int playerHP = 100;
    public static void TakeDamage(int damageAmount)
    {
        playerHP -= damageAmount;
    }
}
