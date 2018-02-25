using UnityEngine;
using System.Collections;
//using Prototype.NetworkLobby;
//using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;


namespace basil.util
{
    [AddComponentMenu("Util/mUtil")]
    public class mUtil : MonoBehaviour
    {

        public bool dump = true;

        public float updateInterval = 1.0F;
        public bool run = false;

        float seconds, minute, hour;
        private double lastInterval;
        private int frames = 0;
        private float fps;
        private double allFrames;
        string theEvent;
        float inputX, inputZ;


        void Awake()
        {
            string me = gameObject.GetInstanceID() + " * " + GetType().FullName + " - "
                                         + System.Reflection.MethodBase.GetCurrentMethod().Name + " - ";
            me += " * " + (gameObject.activeSelf ? "Active" : "Inactive").ToString();

            var comps = gameObject.GetComponents(typeof(Component));
            foreach (Component c in comps)
            {
                me += " \n " + c.GetType();
            }

            foreach (Transform child in transform)
                me += " \n " + child.gameObject.name;

            if (dump) Debug.Log(me);
        }

        void OnDisable()
        {
            string me = gameObject.name + " * " + GetType().FullName + " - "
                                         + System.Reflection.MethodBase.GetCurrentMethod().Name + " - ";
            if (dump) Debug.Log(me);

        }

        void OnEnable()
        {
            string me = gameObject.name + " * " + GetType().FullName + " - "
                                         + System.Reflection.MethodBase.GetCurrentMethod().Name + " - ";
            if (dump) Debug.Log(me);
        }



        void Start()
        {
            lastInterval = Time.realtimeSinceStartup;
            frames = 0;
        }

        void Update()
        {

        }




        void OnApplicationPause()
        {
            string me = gameObject.name + " * " + GetType().FullName + " - "
                                         + System.Reflection.MethodBase.GetCurrentMethod().Name + " - ";
            if (dump) Debug.Log(me);

        }



        void OnGUI()
        {
            if (run) OnGUIimpl();
        }

        void OnGUIimpl()
        {
            Event e = Event.current;
            //if (e != null && !Equals("Repaint", e.ToString()) && !Equals("Layout", e.ToString()))
            if (e.isKey)
            {
                theEvent = string.Format("{0}", e.keyCode);
            }
            if (e.isMouse)
            {
                theEvent = string.Format("{0}", e.mousePosition);
            }

            int w = Screen.width, h = Screen.height;

            Rect rect = new Rect(0, 5, w, h * 2 / 100);
            GUIStyle style = new GUIStyle();
            style.alignment = TextAnchor.UpperCenter;
            style.fontSize = h * 2 / 50;
            style.normal.textColor = new Color(1.0f, 1.0f, 0.5f, 1.0f);
            string text = string.Format("{0:0.} h {1:0.} m {2:0.} s {3:0.} frames {4:0.} fps {5:0.}  {6:0.}x{7:0.} ",
                                       hour, minute, seconds, Time.realtimeSinceStartup, Time.frameCount, fps, w, h);
            GUI.Label(rect, text, style);


            Rect rect2 = new Rect(0, h - 10, w, h * 2 / 100);
            GUIStyle style2 = new GUIStyle();
            style2.alignment = TextAnchor.LowerLeft;
            style2.fontSize = h * 2 / 50;
            style2.normal.textColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            string text2 = string.Format(" xAxis:{0:0.00}  zAxis:{1:0.00} e:{2}",
                                         inputX, inputZ, theEvent);
            GUI.Label(rect2, text2, style2);



            if (GUILayout.Button("Quit"))
            {
                try
                {
                    //LobbyManager.s_Singleton.StopServer();
                    //LobbyManager.s_Singleton.StopClientClbk();
                    //LobbyManager.s_Singleton.ServerReturnToLobby();
                }
                catch (System.Exception ex)
                {
                    Debug.Log(ex.ToString());
                }
            }
        }

    }
}