using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using basil.util;

//namespace basil.util
//{
public static class ExtGameObject
    {

        public static void newGO(this GameObject go)
        {
       
        }
                          
         public static void DeactivateUp( this GameObject go)
        {
            go.transform.DeactiveUp();
        }                       

        public static void DeactivateDown(this GameObject obj)
        {
            foreach (Transform child in obj.transform)
            {
                DeactivateDown(child.gameObject);
            }
 
            obj.SetActive(false);
        }
 
         public static void ActivateUp( this GameObject go)
        {
            go.transform.ActiveUp();
        }
        
 
        public static void ActivateDown(this GameObject obj)
        {
            foreach (Transform child in obj.transform)
            {
                ActivateDown(child.gameObject);
            }
 
            obj.SetActive(true);
        }
 
 
        public static void ToggleActive(this GameObject go)
        {
            go.SetActive(!go.activeSelf);
        }




 


        //public static void SetColor(this GameObject go, float r, float g,float b, float a)
        //{
        //    go.GetComponent<BasicBehaviour>().SetColor(r, g, b, a);  //todo may not have Me
        //}


        public static void SetPlaceInTime(this GameObject go, DateTime dt)
        {
            go.transform.position = new Vector3(0,0, EtcMgr.secondDepthZ * TimeFactory.ADSecs(dt) );
        }


        public static GameObject[] GetRoots(this GameObject go)
        {
            return SceneManager.GetActiveScene().GetRootGameObjects();
        }


        public static void Dump(this GameObject go)
        {
            string  _s = Status(go);
                    _s += State(go);
            Debug.Log(_s);
        }


        public static string Status(this GameObject go)
        {
            string _s = 
                         " " + go.name + " " + go.GetInstanceID()
                       + " " + (go.activeSelf ? "Active " : "Inactive ").ToString()
                       + "-" + (go.activeInHierarchy ? "Active" : "INACTIVE").ToString()
                                    + " ";
            return _s;
        }

        public static string State(this GameObject go)
        {
            string _s = "";
            var comps = go.GetComponents(typeof(Component));
            foreach (Component c in comps) {
                _s += " \n comp: " + c.GetType();

                try
                {
                    Behaviour b = (Behaviour)c as Behaviour;
                    _s += "Behaviour " + b.isActiveAndEnabled.ToString();
                }
                catch (System.Exception ex)
                {
                    // not a Behaviour
                }

            }
            foreach (Transform t in go.transform) { _s += " \n child: " + Status(t.gameObject); }
            return _s;
        }

    public static GameObject GetFirstChild(this GameObject go) {
        GameObject goo = null;
           
           try
        {
             goo = (GameObject)go.GetAllChildren()[0];
        }
        catch (Exception ex)
        {
            U.Log(ex.ToString());
        }

        return goo;
    }
    


        public static ArrayList GetAllChildren(this GameObject go)
        {
            ArrayList list = new ArrayList();
            return GetChildrenHelper(go, list);
        }




        private static ArrayList GetChildrenHelper(GameObject go, ArrayList list)
        {
            if (go == null || go.transform.childCount == 0)
            {
                return list;
            }
            foreach (Transform t in go.transform)
            {
                list.Add(t.gameObject);
                GetChildrenHelper(t.gameObject, list);
            }
            return list;
        }

 

 
 

        //public static GameObject Find(this GameObject go, string nameToFind, bool bSearchInChildren)
        //{
        //    if (bSearchInChildren)
        //    {
        //        var transform = go.transform;
        //        var childCount = transform.childCount;
        //        //Debug.LogError( go.name + " ChildCount: " + childCount);
        //        for (int i = 0; i < childCount; ++i)
        //        {
        //            var child = transform.GetChild(i);
        //            if (child.gameObject.name == nameToFind)
        //                return child.gameObject;
        //            GameObject result = child.gameObject.Find(nameToFind, bSearchInChildren);
        //            if (result != null) return result;
        //        }
        //        return null;
        //    }
        //    else
        //    {
        //        return GameObject.Find(nameToFind);
        //    }
        //}

 
        //#region Layer Methods
 
        //public static IList<GameObject> FindGameObjectOnLayer(int mask)
        //{
        //    var lst = new List<GameObject>();
        //    var arr = GameObject.FindObjectsOfType(typeof(GameObject));
 
        //    foreach (GameObject go in arr)
        //    {
        //        if (((1 << go.layer)  mask) > 0)
        //            lst.Add(go);
        //    }
 
        //    return lst;
        //}
 
        //public static void ChangeLayer(this GameObject obj, int layer, bool recursive, params string[] ignoreNames)
        //{
        //    obj.layer = layer;
 
        //    if (recursive)
        //    {
        //        foreach (Transform child in obj.transform)
        //        {
        //            if (!StringUtil.Equals(child.name, ignoreNames))
        //            {
        //                ChangeLayer(child.gameObject, layer, recursive, ignoreNames);
        //            }
        //        }
        //    }
        //}
 
        //#endregion
 
        //#region Spawnable Methods
 
        //public static bool IsSpawnedObject(this GameObject obj)
        //{
        //    return obj.GetComponent<SpawnedObjectController>() != null;
        //}
 
        ///// <summary>
        ///// Like DestroyAll but will test if Spawned object first and properly handle that...
        ///// </summary>
        ///// <param name="obj"></param>
        //public static void Kill(this GameObject obj)
        //{
        //    var comp = obj.GetComponent<SpawnedObjectController>();
 
        //    if (comp != null)
        //    {
        //        comp.DespawnObject();
        //    }
        //    else
        //    {
        //        obj.DestroyAll();
        //    }
        //}
 
        ///// <summary>
        ///// Destroys self and all children
        ///// </summary>
        ///// <param name="obj"></param>
        //public static void DestroyAll(this GameObject obj)
        //{
        //    foreach (Transform child in obj.transform)
        //    {
        //        DestroyAll(child.gameObject);
        //    }
 
        //    Object.Destroy(obj);
        //}
 

 
 
 
        //public static void AddChild(this GameObject obj, GameObject child)
        //{
        //    child.transform.parent = obj.transform;
        //}
 
        //public static void AddChild(this GameObject obj, Transform child)
        //{
        //    child.parent = obj.transform;
        //}
 
        //public static void AddChild(this Transform obj, GameObject child)
        //{
        //    child.transform.parent = obj;
        //}
 
        //public static void AddChild(this Transform obj, Transform child)
        //{
        //    child.parent = obj;
        //}
       
        //public static Transform Search(this GameObject go, string spath)
        //{
        //    return Search(go.transform, spath);
        //}
 
        //public static Transform Search(this Transform trans, string spath)
        //{
        //    if (!spath.Contains("*"))
        //    {
        //        return trans.Find(spath);
        //    }
        //    else
        //    {
        //        var arr = spath.Split('/');
        //        string sval;
        //        spath = "";
 
        //        for (int i = 0; i < arr.Length; i++)
        //        {
        //            sval = arr[i];
 
        //            if (sval == "*")
        //            {
        //                if (spath != "")
        //                {
        //                    trans = trans.Find(spath);
        //                    if (trans == null) return null;
        //                    spath = "";
        //                }
 
        //                i++;
        //                if (i >= arr.Length)
        //                    return (trans.childCount > 0) ? trans.GetChild(0) : null;
        //                else
        //                {
        //                    sval = arr[i];
        //                    //now we're going to do our recursing search
        //                    trans = Search(trans, sval);
        //                    if (trans == null) return null;
        //                }
        //            }
        //            else
        //            {
        //                if (spath != "") spath += "/";
        //                spath += sval;
        //            }
 
        //        }
 
        //        return trans;
        //    }
        //}
 
        //public static Transform SearchChild(this GameObject go, string sname)
        //{
        //    return SearchChild(go.transform, sname);
        //}
       
        //public static Transform SearchChild(this Transform trans, string sname)
        //{
        //    foreach (Transform child in trans)
        //    {
        //        if (child.name == sname) return child;
        //    }
 
        //    foreach (Transform child in trans)
        //    {
        //        var nxt = Search(child, sname);
        //        if (nxt != null) return nxt;
        //    }
 
        //    return null;
        //}
 
        //#endregion
 
        //#region ZeroOut Methods
 
        //public static void ZeroOut(this GameObject go, bool bIgnoreScale)
        //{
        //    go.transform.localPosition = Vector3.zero;
        //    go.transform.localRotation = Quaternion.identity;
        //    if (!bIgnoreScale) go.transform.localScale = Vector3.one;
 
        //    if (go.rigidbody != null  !go.rigidbody.isKinematic)
        //    {
        //        go.rigidbody.velocity = Vector3.zero;
        //        go.rigidbody.angularVelocity = Vector3.zero;
 
        //    }
        //}
 
        //public static void ZeroOut(this Transform trans, bool bIgnoreScale)
        //{
        //    trans.localPosition = Vector3.zero;
        //    trans.localRotation = Quaternion.identity;
        //    if (!bIgnoreScale) trans.localScale = Vector3.one;
        //}
 
        //public static void ZeroOut(this Rigidbody body)
        //{
        //    if (body.isKinematic) return;
 
        //    body.velocity = Vector3.zero;
        //    body.angularVelocity = Vector3.zero;
        //}
 
        //#endregion
 
        //public static bool Equals(this object obj, params object[] any)
        //{
        //    return System.Array.IndexOf(any, obj) >= 0;
        //}
 
    }
//}
 
