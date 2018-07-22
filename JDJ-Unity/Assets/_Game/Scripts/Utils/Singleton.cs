using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
                if(instance == null)
                {
                    GameObject go = new GameObject(typeof(T).Name, typeof(T));
                    instance = go.GetComponent<T>();
                }
            }
            return instance;
        }
    }

}
