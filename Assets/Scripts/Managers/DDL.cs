using UnityEngine;

// Make the object with this script non destructible
public class DDL : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
