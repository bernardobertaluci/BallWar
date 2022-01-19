using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Earth : MonoBehaviour
{
    
    public void Die()
    {
        Destroy(gameObject);
        Time.timeScale = 0;
    }


}
