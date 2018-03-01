using UnityEngine;
using basil.util;
using System;
using System.Reflection;

//https://gamedev.stackexchange.com/questions/116009/in-unity-how-do-i-correctly-implement-the-singleton-pattern


namespace basil.patterns
{
    public class Singleton<T> : BasicBehaviour where T : BasicBehaviour
    {
        private static T _instance;

        private static object _lock = new object();
        
        
        public void 
       SingletonAwake()
        {
            U.LData( MethodBase.GetCurrentMethod().DeclaringType.Name +"\t dumping :"+ dump, _instance );
        }

        public static T Instance
        {            
            get
            {  
            Debug.Log("   ");
            
                if (applicationIsQuitting)
                {
                    U.LWarning("[Singleton] Instance '" + typeof(T) +
                        "' already destroyed on application quit." +
                        " Won't create again - returning null.");
                    return null;
                }

                lock (_lock)
                {
                    if (_instance == null)
                    {
                        UnityEngine.Object[] oa = FindObjectsOfType(typeof(T));
                        if (oa.Length > 1)
                        {
                            U.LError("[Singleton] Something went really wrong " +
                                " - there should never be more than 1 singleton!" +
                                " Destroying something now. Cross fingers.");
                               DestroyRogueImposter(oa[1]);
                            return _instance;
                        }


                        _instance = (T)FindObjectOfType(typeof(T));




                        if (_instance == null)
                        {
                            GameObject singleton = new GameObject( );
                            singleton.transform.parent = U.gm.transform;
                            _instance = singleton.AddComponent<T>();
                            singleton.name = "(singleton) " + typeof(T).ToString();

                            DontDestroyOnLoad(singleton);

                            U.Log("[Singleton] An instance of " + typeof(T) +
                                " is needed in the scene, so '" + singleton +
                                "' was created with DontDestroyOnLoad.");
                        }
                        else
                        {
                            U.Log("[Singleton] Using instance already created: " +
                                _instance.gameObject.name);
                        }
                    }

                    return _instance;
                }
            }
        }


        private static void DestroyRogueImposter(UnityEngine.Object SingletonWithoutProperPaperwork)
        {
            if (Application.isPlaying)
                Destroy(SingletonWithoutProperPaperwork);
            else
                DestroyImmediate(SingletonWithoutProperPaperwork);
        }

        private static bool applicationIsQuitting = false;
        /// <summary>
        /// When Unity quits, it destroys objects in a random order.
        /// In principle, a Singleton is only destroyed when application quits.
        /// If any script calls Instance after it have been destroyed, 
        ///   it will create a buggy ghost object that will stay on the Editor scene
        ///   even after stopping playing the Application. Really bad!
        /// So, this was made to be sure we're not creating that buggy ghost object.
        /// </summary>
        public void OnDestroy()
        {
            applicationIsQuitting = true;
        }
    }

}