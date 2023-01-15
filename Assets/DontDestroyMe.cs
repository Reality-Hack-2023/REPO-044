using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMe : MonoBehaviour
{
    public static DontDestroyMe Instance;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null) {
            Instance = this;
            for(int i = 0; i < transform.childCount; i++) {
                transform.GetChild(i).gameObject.SetActive(true);
            }

            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    
    void OnDestroy() {
        if (Instance == this) {
            Instance = null;
        }
    }
}
