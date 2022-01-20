using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Earth : MonoBehaviour
{
    private int _money;
    public void Die()
    {
        Destroy(gameObject);
        Time.timeScale = 0;
    }
}
