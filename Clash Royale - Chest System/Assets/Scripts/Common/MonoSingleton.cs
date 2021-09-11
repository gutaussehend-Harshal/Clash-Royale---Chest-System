using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Implemented MonoSingletonGeneric class for chests.
/// </summary>
namespace Outscal.ChestRoyalSystem
{
    // public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    // {
    //     private static T instance;
    //     private static object m_lock = new object();

    //     public static T GetInstance()
    //     {
    //         lock (m_lock)
    //         {
    //             if (instance == null)
    //             {
    //                 instance = FindObjectOfType<T>();
    //                 if (instance == null)
    //                 {
    //                     GameObject obj = new GameObject();
    //                     obj.name = typeof(T).ToString();
    //                     instance = obj.AddComponent<T>();
    //                     DontDestroyOnLoad(obj);
    //                 }
    //             }
    //         }
    //         return instance;
    //     }
    // }

    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T instance;
        public static T Instance { get { return instance; } }

        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = (T)this;
            }
            else
            {
                Debug.LogError("Some one trying to create a duplicate singleton");
                Destroy(this);
            }
        }
    }
}